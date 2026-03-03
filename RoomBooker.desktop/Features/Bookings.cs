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
        private void AddBooking()
        {
            using var dialog = new BookingDialog(_context.Customers.ToList(), _context.Rooms.ToList());
            if (dialog.ShowDialog(this) != DialogResult.OK) return;
            _context.Bookings.Add(dialog.Booking);
            _context.SaveChanges();
            LoadData();
        }

        private void EditBooking()
        {
            if (bookingBindingSource.Current is not Booking selected) return;
            var booking = _context.Bookings.Find(selected.Id);
            if (booking is null) return;

            using var dialog = new BookingDialog(_context.Customers.ToList(), _context.Rooms.ToList(), booking);
            if (dialog.ShowDialog(this) != DialogResult.OK) return;
            _context.SaveChanges();
            LoadData();
        }

        private void DeleteBooking()
        {
            if (bookingBindingSource.Current is not Booking selected) return;
            if (!ConfirmDelete($"Booking #{selected.Id}")) return;

            var booking = _context.Bookings.Find(selected.Id);
            if (booking is null) return;
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            LoadData();
        }
    }
}
