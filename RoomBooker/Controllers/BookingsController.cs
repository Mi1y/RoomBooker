using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoomBooker.Data;
using RoomBooker.Models;

namespace RoomBooker.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AppDbContext _context;

        public BookingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Bookings
        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .ToListAsync();
            return View(bookings);
        }

        // GET: /Bookings/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(b => b.Id == id);
            return View(booking);
        }

        // GET: /Bookings/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        // POST: /Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await PopulateDropdowns(booking.CustomerId, booking.RoomId);
            return View(booking);
        }

        // GET: /Bookings/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            await PopulateDropdowns(booking?.CustomerId, booking?.RoomId);
            return View(booking);
        }

        // POST: /Bookings/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Update(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await PopulateDropdowns(booking.CustomerId, booking.RoomId);
            return View(booking);
        }

        // GET: /Bookings/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(b => b.Id == id);
            return View(booking);
        }

        // POST: /Bookings/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Remove(booking);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns(int? selectedCustomerId = null, int? selectedRoomId = null)
        {
            var customers = await _context.Customers.ToListAsync();
            var rooms = await _context.Rooms.ToListAsync();

            ViewBag.CustomerId = new SelectList(customers, "Id", "Name", selectedCustomerId);
            ViewBag.RoomId = new SelectList(rooms, "ID", "RoomNumber", selectedRoomId);
        }
    }
}