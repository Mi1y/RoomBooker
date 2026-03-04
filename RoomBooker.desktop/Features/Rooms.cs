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
    }
}
