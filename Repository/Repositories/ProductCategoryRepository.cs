using Domain.Data;
using Domain.Models;

namespace Repository.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(WebShopContext context) : base(context)
        {
            
        }
    }
}
