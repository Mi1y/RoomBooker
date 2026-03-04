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
    }
}
