using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RoomBooker.desktop.Controllers;

namespace RoomBooker.desktop
{
    public partial class MainForm : Form
    {
        private FormController _controller;

        public MainForm()
        {
            InitializeComponent();
            _controller = new FormController(this);
            _controller.Initialize();
        }

        // binding sources for controller
        public BindingSource CustomerBindingSource => customerBindingSource;
        public BindingSource RoomBindingSource => roomBindingSource;
        public BindingSource BookingBindingSource => bookingBindingSource;

        // data grids for controller
        public DataGridView DataGridView1 => dataGridView1;
        public DataGridView DataGridView2 => dataGridView2;
        public DataGridView DataGridView3 => dataGridView3;

        // tab pages for controller
        public TabPage TabPageCustomers => tabPageCustomers;
        public TabPage TabPageRooms => tabPageRooms;
        public TabPage TabPageBookings => tabPageBookings;

        public void BtnAdd_Click(object? sender, EventArgs e)
        {
            _controller.HandleAddClick(tabControl1.SelectedIndex);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _controller.Cleanup();
            base.OnFormClosed(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (dataGridView1.CurrentRow?.DataBoundItem is not RoomBooker.Models.Customer customer) return;

            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "colEdit": _controller.HandleCustomerEdit(customer); break;
                case "colDelete": _controller.HandleCustomerDelete(customer); break;
                case "colViewBookings": _controller.ShowCustomerBookings(customer); break;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (dataGridView2.CurrentRow?.DataBoundItem is not RoomBooker.Models.Room room) return;

            switch (dataGridView2.Columns[e.ColumnIndex].Name)
            {
                case "colEdit": _controller.HandleRoomEdit(room); break;
                case "colDelete": _controller.HandleRoomDelete(room); break;
                case "colViewBookings": _controller.ShowRoomBookings(room); break;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dataGridView3.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (dataGridView3.CurrentRow?.DataBoundItem is not RoomBooker.Models.Booking booking) return;

            switch (dataGridView3.Columns[e.ColumnIndex].Name)
            {
                case "colEdit": _controller.HandleBookingEdit(booking); break;
                case "colDelete": _controller.HandleBookingDelete(booking); break;
            }
        }

        private void tabPageCustomers_Click(object sender, EventArgs e)
        {

        }
    }
}

