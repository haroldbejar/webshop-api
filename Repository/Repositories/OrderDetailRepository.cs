using Domain.Data;
using Domain.Models;

namespace Repository.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(WebShopContext context) : base (context)
        {
          
        }
    }
}
