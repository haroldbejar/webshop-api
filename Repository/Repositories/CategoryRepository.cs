using Domain.Data;
using Domain.Models;

namespace Repository.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategotyRepository
    {
        public CategoryRepository(WebShopContext context) : base (context)
        {
            
        }
    }
}
