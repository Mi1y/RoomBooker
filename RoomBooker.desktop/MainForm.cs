using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RoomBooker.Data;
using RoomBooker.Models;
using RoomBooker.desktop.Features;
using RoomBooker.desktop.Dialog;

namespace RoomBooker.desktop
{
    public partial class MainForm : Form
    {
        private readonly AppDbContext _context;
        private readonly BookingsFeature _bookings;
        private readonly CustomersFeature _customers;
        private readonly RoomsFeature _rooms;

        public MainForm()
        {
            InitializeComponent();
            SetupDataGridButtons();
            _context = CreateDbContext();
            _customers = new CustomersFeature(_context, LoadData);
            _rooms = new RoomsFeature(_context, LoadData);
            _bookings = new BookingsFeature(_context, LoadData);
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
            customerBindingSource.DataSource = _context.Customers.ToList();
            roomBindingSource.DataSource = _context.Rooms.ToList();
            bookingBindingSource.DataSource = _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .ToList();
        }

        private void SetupDataGridButtons()
        {
            AddButtonColumns(dataGridView1);
            AddButtonColumns(dataGridView2);
            AddButtonColumns(dataGridView3);

            AddAddButton(tabPageCustomers, BtnAdd_Click);
            AddAddButton(tabPageRooms, BtnAdd_Click);
            AddAddButton(tabPageBookings, BtnAdd_Click);
        }
        private static void AddButtonColumns(DataGridView grid)
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
        }

        private static void AddAddButton(TabPage tab, EventHandler handler)
        {
            var btn = new Button { Text = "Add", Dock = DockStyle.Bottom, Height = 35 };
            btn.Click += handler;
            tab.Controls.Add(btn);
        }
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    using (var dialog = new CustomerDialog())
                    {
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                            _customers.Add(dialog.Customer);
                    }
                    break;
                case 1:
                    using (var dialog = new RoomDialog())
                    {
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                            _rooms.Add(dialog.Room);
                    }
                    break;
                case 2:
                    var allBookings = _context.Bookings.Include(b => b.Customer).ToList();
                    using (var dialog = new BookingDialog(_context.Customers.ToList(), _context.Rooms.ToList(), allBookings))
                    {
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                            _bookings.Add(dialog.Booking);
                    }
                    break;
            }
        }


        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }

        private void tabControl_Click(object sender, EventArgs e)
        {

        }

        private void tabPageCustomers_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (dataGridView1.CurrentRow?.DataBoundItem is not Customer customer) return;

            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "colEdit":
                    using (var dialog = new CustomerDialog(customer))
                    {
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                            _customers.Edit(customer);
                    }
                    break;
                case "colDelete":
                    if (ConfirmDelete(customer.Name))
                        _customers.Delete(customer.Id);
                    break;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (dataGridView2.CurrentRow?.DataBoundItem is not Room room) return;

            switch (dataGridView2.Columns[e.ColumnIndex].Name)
            {
                case "colEdit":
                    using (var dialog = new RoomDialog(room))
                    {
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                            _rooms.Edit(room);
                    }
                    break;
                case "colDelete":
                    if (ConfirmDelete($"Room {room.RoomNumber}"))
                        _rooms.Delete(room.ID);
                    break;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dataGridView3.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (dataGridView3.CurrentRow?.DataBoundItem is not Booking booking) return;

            switch (dataGridView3.Columns[e.ColumnIndex].Name)
            {
                case "colEdit":
                    var allBookings = _context.Bookings.Include(b => b.Customer).ToList();
                    using (var dialog = new BookingDialog(_context.Customers.ToList(), _context.Rooms.ToList(), allBookings, booking))
                    {
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                            _bookings.Edit(booking);
                    }
                    break;
                case "colDelete":
                    if (ConfirmDelete($"Booking #{booking.Id}"))
                        _bookings.Delete(booking.Id);
                    break;
            }
        }

        private static bool ConfirmDelete(string name) =>
            MessageBox.Show($"Delete \"{name}\"?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
    }
}
