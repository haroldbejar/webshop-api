using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(WebShopContext context) : base (context) { }

        public async Task<IReadOnlyCollection<OrderDetail>> GetDetailsByOrderId(int orderId)
        {
            return await _context.OrderDetails.Where(d => d.OrderId == orderId).ToListAsync();
        }

        public async Task<IReadOnlyCollection<OrderDetail>> GetDetailsByProductId(int productId)
        {
            return await _context.OrderDetails.Where(d => d.ProductId == productId).ToListAsync();
        }
    }
}
