using Microsoft.EntityFrameworkCore;
using RoomBooker.Models;
using RoomBooker_Desktop.Dialog;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBooker_Desktop
{
    public partial class MainForm
    {

        private void AddCustomer()
        {
            using var dialog = new CustomerDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK) return;
            _context.Customers.Add(dialog.Customer);
            _context.SaveChanges();
            LoadData();
        }

        private void EditCustomer()
        {
            if (customerBindingSource.Current is not Customer selected) return;
            var customer = _context.Customers.Find(selected.Id);
            if (customer is null) return;

            using var dialog = new CustomerDialog(customer);
            if (dialog.ShowDialog(this) != DialogResult.OK) return;
            _context.SaveChanges();
            LoadData();
        }

        private void DeleteCustomer()
        {
            if (customerBindingSource.Current is not Customer selected) return;
            if (!ConfirmDelete(selected.Name)) return;

            var customer = _context.Customers.Find(selected.Id);
            if (customer is null) return;
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            LoadData();
        }
    }
}
