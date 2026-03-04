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
    }
}
