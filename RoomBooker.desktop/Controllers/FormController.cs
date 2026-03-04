using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RoomBooker.Data;
using RoomBooker.Models;
using RoomBooker.desktop.Features;
using RoomBooker.desktop.Dialog;

namespace RoomBooker.desktop.Controllers
{
    internal sealed class FormController
    {
        private readonly MainForm _form;
        private readonly AppDbContext _context;
        private readonly BookingsFeature _bookings;
        private readonly CustomersFeature _customers;
        private readonly RoomsFeature _rooms;

        public FormController(MainForm form)
        {
            _form = form;
            _context = CreateDbContext();
            _customers = new CustomersFeature(_context, LoadData);
            _rooms = new RoomsFeature(_context, LoadData);
            _bookings = new BookingsFeature(_context, LoadData);
        }

        public void Initialize()
        {
            SetupDataGridButtons();
            LoadData();
        }

        private static AppDbContext CreateDbContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(config.GetConnectionString("DefaultConnection"))
                .Options;

            return new AppDbContext(options);
        }

        private void LoadData()
        {
            _form.CustomerBindingSource.DataSource = _context.Customers.ToList();
            _form.RoomBindingSource.DataSource = _context.Rooms.ToList();
            var bookings = _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .ToList();
            _form.BookingBindingSource.DataSource = bookings;
        }

        private enum GridType { Customers, Rooms, Bookings }

        private void SetupDataGridButtons()
        {
            AddButtonColumns(_form.DataGridView1, GridType.Customers);
            AddButtonColumns(_form.DataGridView2, GridType.Rooms);
            AddButtonColumns(_form.DataGridView3, GridType.Bookings);

            AddButton(_form.TabPageCustomers, _form.BtnAdd_Click);
            AddButton(_form.TabPageRooms, _form.BtnAdd_Click);
            AddButton(_form.TabPageBookings, _form.BtnAdd_Click);
        }

        private static void AddButtonColumns(DataGridView grid, GridType gridType)
        {
            grid.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colEdit",
                HeaderText = "",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Width = 80,
                FlatStyle = FlatStyle.Flat
            });
            grid.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 90,
                FlatStyle = FlatStyle.Flat
            });

            if (gridType != GridType.Bookings)
            {
                grid.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "colViewBookings",
                    HeaderText = "",
                    Text = "Bookings",
                    UseColumnTextForButtonValue = true,
                    Width = 80,
                    FlatStyle = FlatStyle.Flat
                });
            }
        }

        private static void AddButton(TabPage tab, EventHandler handler)
        {
            var btn = new Button { Text = "Add", Dock = DockStyle.Top, Height = 35 };
            btn.Click += handler;
            tab.Controls.Add(btn);
        }

        public void HandleAddClick(int tabIndex)
        {
            switch (tabIndex)
            {
                case 0:
                    using (var dialog = new CustomerDialog())
                    {
                        if (dialog.ShowDialog(_form) == DialogResult.OK)
                            _customers.Add(dialog.Customer);
                    }
                    break;
                case 1:
                    using (var dialog = new RoomDialog())
                    {
                        if (dialog.ShowDialog(_form) == DialogResult.OK)
                            _rooms.Add(dialog.Room);
                    }
                    break;
                case 2:
                    var allBookings = _context.Bookings.Include(b => b.Customer).ToList();
                    using (var dialog = new BookingDialog(_context.Customers.ToList(), _context.Rooms.ToList(), allBookings))
                    {
                        if (dialog.ShowDialog(_form) == DialogResult.OK)
                            _bookings.Add(dialog.Booking);
                    }
                    break;
            }
        }

        public void HandleCustomerEdit(Customer customer)
        {
            using (var dialog = new CustomerDialog(customer))
            {
                if (dialog.ShowDialog(_form) == DialogResult.OK)
                    _customers.Edit(customer);
            }
        }

        public void HandleCustomerDelete(Customer customer)
        {
            if (ConfirmDelete(customer.Name))
                _customers.Delete(customer.Id);
        }

        public void HandleRoomEdit(Room room)
        {
            using (var dialog = new RoomDialog(room))
            {
                if (dialog.ShowDialog(_form) == DialogResult.OK)
                    _rooms.Edit(room);
            }
        }

        public void HandleRoomDelete(Room room)
        {
            if (ConfirmDelete($"Room {room.RoomNumber}"))
                _rooms.Delete(room.ID);
        }

        public void HandleBookingEdit(Booking booking)
        {
            var allBookings = _context.Bookings.Include(b => b.Customer).ToList();
            using (var dialog = new BookingDialog(_context.Customers.ToList(), _context.Rooms.ToList(), allBookings, booking))
            {
                if (dialog.ShowDialog(_form) == DialogResult.OK)
                    _bookings.Edit(booking);
            }
        }

        public void HandleBookingDelete(Booking booking)
        {
            if (ConfirmDelete($"Booking #{booking.Id}"))
                _bookings.Delete(booking.Id);
        }

        public void Cleanup()
        {
            _context.Dispose();
        }

        public void ShowCustomerBookings(Customer customer)
        {
            var bookings = _customers.GetCustomerBookings(customer.Id);
            if (bookings.Count == 0)
            {
                MessageBox.Show($"{customer.Name} has no bookings.", "Customer Bookings");
                return;
            }

            var message = $"{customer.Name}'s Bookings:\n\n";
            decimal totalAmount = 0;
            foreach (var b in bookings)
            {
                message += $"Room {b.RoomNumber}: {b.DateFrom:dd MMM yyyy} to {b.DateTo:dd MMM yyyy} ({b.Duration} nights) - ${b.TotalPrice:F2}\n";
                totalAmount += b.TotalPrice;
            }
            message += $"\nTotal Amount: ${totalAmount:F2}";
            MessageBox.Show(message, "Customer Bookings");
        }

        public void ShowRoomBookings(Room room)
        {
            var count = _rooms.GetRoomBookingCount(room.ID);
            var details = _rooms.GetRoomBookingDetails(room.ID);

            if (count == 0)
            {
                MessageBox.Show($"Room {room.RoomNumber} has no bookings.", "Room Bookings");
                return;
            }

            var message = $"Room {room.RoomNumber} - {count} booking(s):\n\n";
            decimal totalRevenue = 0;
            foreach (var b in details)
            {
                message += $"{b.CustomerName}: {b.DateFrom:dd MMM yyyy} to {b.DateTo:dd MMM yyyy} - ${b.TotalPrice:F2}\n";
                totalRevenue += b.TotalPrice;
            }
            message += $"\nTotal Revenue: ${totalRevenue:F2}";
            MessageBox.Show(message, "Room Bookings");
        }

        private static bool ConfirmDelete(string name) =>
            MessageBox.Show($"Delete \"{name}\"?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
    }
}
