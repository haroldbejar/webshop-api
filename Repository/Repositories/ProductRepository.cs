using Domain.Data;
using Domain.Models;

namespace Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(WebShopContext context) : base(context)
        {
            
        }
    }
}
