using Microsoft.EntityFrameworkCore;
using RoomBooker.Data;
using RoomBooker.Models;

namespace RoomBooker.desktop.Features
{
    internal sealed class CustomersFeature
    {
        private readonly AppDbContext _context;
        private readonly Action _loadData;

        public CustomersFeature(AppDbContext context, Action loadData)
        {
            _context = context;
            _loadData = loadData;
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            _loadData();
        }

        public void Edit(Customer customer)
        {
            _context.SaveChanges();
            _loadData();
        }

        public void Delete(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer is not null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                _loadData();
            }
        }

        public List<BookingInfo> GetCustomerBookings(int customerId)
        {
            return _context.Bookings
                .Where(b => b.CustomerId == customerId)
                .Include(b => b.Room)
                .Select(b => new BookingInfo(
                    b.Id,
                    b.Room!.RoomNumber,
                    b.DateFrom,
                    b.DateTo,
                    b.DateFrom.HasValue && b.DateTo.HasValue 
                        ? b.DateTo.Value.DayNumber - b.DateFrom.Value.DayNumber 
                        : 0,
                    b.DateFrom.HasValue && b.DateTo.HasValue 
                        ? (decimal)(b.DateTo.Value.DayNumber - b.DateFrom.Value.DayNumber) * b.Room!.PricePerNight
                        : 0
                ))
                .ToList();
        }
    }

    public record BookingInfo(int BookingId, string RoomNumber, DateOnly? DateFrom, DateOnly? DateTo, int Duration, decimal TotalPrice);
}
