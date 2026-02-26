using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomBooker.Data;
using RoomBooker.Models;

namespace RoomBooker.Controllers
{
    public class RoomsController : Controller
    {
        private readonly AppDbContext _context;

        public RoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Rooms
        public async Task<IActionResult> Index()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return View(rooms);
        }

        // GET: /Rooms/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            var room = await _context.Rooms
                .Include(r => r.Bookings)
                .ThenInclude(b => b.Customer)
                .FirstOrDefaultAsync(r => r.ID == id);
            return View(room);
        }

        // GET: /Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: /Rooms/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            var room = await _context.Rooms.FindAsync(id);
            return View(room);
        }

        // POST: /Rooms/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Update(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: /Rooms/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.ID == id);
            return View(room);
        }

        // POST: /Rooms/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Remove(room);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}