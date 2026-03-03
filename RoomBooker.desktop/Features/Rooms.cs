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
        private void AddRoom()
        {
            using var dialog = new RoomDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK) return;
            _context.Rooms.Add(dialog.Room);
            _context.SaveChanges();
            LoadData();
        }

        private void EditRoom()
        {
            if (roomBindingSource.Current is not Room selected) return;
            var room = _context.Rooms.Find(selected.ID);
            if (room is null) return;

            using var dialog = new RoomDialog(room);
            if (dialog.ShowDialog(this) != DialogResult.OK) return;
            _context.SaveChanges();
            LoadData();
        }

        private void DeleteRoom()
        {
            if (roomBindingSource.Current is not Room selected) return;
            if (!ConfirmDelete($"Room {selected.RoomNumber}")) return;

            var room = _context.Rooms.Find(selected.ID);
            if (room is null) return;
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            LoadData();
        }
    }
}
