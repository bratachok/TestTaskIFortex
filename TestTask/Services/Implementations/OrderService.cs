using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Data;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext context;
        public OrderService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<Order> GetOrder()
        {
            Order result = context.Orders.Where(p => p.Price * p.Quantity == context.Orders.Max(o => o.Price * o.Quantity)).FirstOrDefault();
            return result;
        }

        public async Task<List<Order>> GetOrders()
        {
            List<Order> result = context.Orders.Where(p => p.Quantity >= 10).ToList();
            return result;
        }
    }
}
