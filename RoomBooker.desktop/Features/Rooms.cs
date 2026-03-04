using Microsoft.EntityFrameworkCore;
using RoomBooker.Data;
using RoomBooker.Models;

namespace RoomBooker.desktop.Features
{
    internal sealed class RoomsFeature
    {
        private readonly AppDbContext _context;
        private readonly Action _loadData;

        public RoomsFeature(AppDbContext context, Action loadData)
        {
            _context = context;
            _loadData = loadData;
        }

        public void Add(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            _loadData();
        }

        public void Edit(Room room)
        {
            _context.SaveChanges();
            _loadData();
        }

        public void Delete(int roomId)
        {
            var room = _context.Rooms.Find(roomId);
            if (room is not null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
                _loadData();
            }
        }

        public int GetRoomBookingCount(int roomId)
        {
            return _context.Bookings.Count(b => b.RoomId == roomId);
        }

        public List<RoomBookingInfo> GetRoomBookingDetails(int roomId)
        {
            var room = _context.Rooms.Find(roomId);
            return _context.Bookings
                .Where(b => b.RoomId == roomId)
                .Include(b => b.Customer)
                .Select(b => new RoomBookingInfo(
                    b.Id,
                    b.Customer!.Name,
                    b.DateFrom,
                    b.DateTo,
                    b.DateFrom.HasValue && b.DateTo.HasValue 
                        ? (decimal)(b.DateTo.Value.DayNumber - b.DateFrom.Value.DayNumber) * room!.PricePerNight
                        : 0
                ))
                .ToList();
        }
    }

    public record RoomBookingInfo(int BookingId, string CustomerName, DateOnly? DateFrom, DateOnly? DateTo, decimal TotalPrice);
}
