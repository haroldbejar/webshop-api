using Domain.Data;
using Domain.Models;

namespace Repository.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(WebShopContext context) : base (context)
        {
            
        }
    }
}
