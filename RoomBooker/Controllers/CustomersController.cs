using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomBooker.Data;
using RoomBooker.Models;

namespace RoomBooker.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Customers/Create - show form
        public IActionResult Create()
        {
            return View();
        }

        // GET: /Customers
        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers.ToListAsync();
            return View(customers);
        }

        // GET: /Customers/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            var customer = await _context.Customers
                .Include(c => c.Bookings)
                .FirstOrDefaultAsync(c => c.Id == id);

            return View(customer);
        }

        // GET: /Customers/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            var customer = await _context.Customers.FindAsync(id);

            return View(customer);
        }

        // GET: /Customers/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return View(customer);
        }
        // POST: /Customers/Create
        // Validate - prevent CSRF attacks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // POST: /Customers/Edit/{id}
        // Validate - prevent CSRF attacks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // POST: /Customers/Delete/{id}
        // Validate - prevent CSRF attacks
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
