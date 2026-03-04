using Microsoft.EntityFrameworkCore;
using RoomBooker.Data;
using RoomBooker.Models;

namespace RoomBooker.desktop.Features
{
    internal sealed class BookingsFeature
    {
        private readonly AppDbContext _context;
        private readonly Action _loadData;

        public BookingsFeature(AppDbContext context, Action loadData)
        {
            _context = context;
            _loadData = loadData;
        }

        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            _loadData();
        }

        public void Edit(Booking booking)
        {
            _context.SaveChanges();
            _loadData();
        }

        public void Delete(int bookingId)
        {
            var booking = _context.Bookings.Find(bookingId);
            if (booking is not null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
                _loadData();
            }
        }

        public decimal CalculateBookingPrice(Booking booking)
        {
            var room = _context.Rooms.Find(booking.RoomId);
            if (room == null || !booking.DateFrom.HasValue || !booking.DateTo.HasValue)
                return 0;

            var nights = (booking.DateTo.Value.ToDateTime(TimeOnly.MinValue) - booking.DateFrom.Value.ToDateTime(TimeOnly.MinValue)).Days;
            return (decimal)nights * room.PricePerNight;
        }
    }
}
