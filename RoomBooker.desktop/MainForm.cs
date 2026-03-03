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

namespace RoomBooker_Desktop
{
    public partial class MainForm : Form
    {
        private readonly AppDbContext _context;
        public MainForm()
        {
            InitializeComponent();
            SetupDataGridButtons();
            _context = CreateDbContext();
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
                case 0: AddCustomer(); break;
                case 1: AddRoom(); break;
                case 2: AddBooking(); break;
            }
        }


        private static bool ConfirmDelete(string name) =>
            MessageBox.Show($"Delete \"{name}\"?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

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

            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "colEdit": EditCustomer(); break;
                case "colDelete": DeleteCustomer(); break;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);

            switch (dataGridView2.Columns[e.ColumnIndex].Name)
            {
                case "colEdit": EditRoom(); break;
                case "colDelete": DeleteRoom(); break;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dataGridView3.CommitEdit(DataGridViewDataErrorContexts.Commit);

            switch (dataGridView3.Columns[e.ColumnIndex].Name)
            {
                case "colEdit": EditBooking(); break;
                case "colDelete": DeleteBooking(); break;
            }
        }
    }
}
