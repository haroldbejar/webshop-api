using Domain.Data;
using Domain.Models;

namespace Repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(WebShopContext context) : base (context)
        {
            
        }
    }
}
