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

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
