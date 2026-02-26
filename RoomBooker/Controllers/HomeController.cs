using Microsoft.AspNetCore.Mvc;
using RoomBooker.Models;
using System.Diagnostics;
using RoomBooker.Data;
using Microsoft.EntityFrameworkCore;

namespace RoomBooker.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CustomersCount = await _context.Customers.CountAsync();
            ViewBag.RoomsCount = await _context.Rooms.CountAsync();
            ViewBag.BookingsCount = await _context.Bookings.CountAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
