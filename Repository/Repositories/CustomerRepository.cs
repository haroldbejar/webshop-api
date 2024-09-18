using Domain.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(WebShopContext context) : base (context)
        {
            
        }

        public async Task<CustomerDTO> GetCustomerByUserId(int userId)
        {
            var query = from c in _context.Customers
                        join u in _context.Users on c.UserId equals u.Id
                        where c.UserId == userId
                        select new CustomerDTO
                        {
                            CustomerId = c.CustomerId, 
                            Name = c.Name,
                            Email = c.Email,
                            Address = c.Address,
                            UserId = u.Id
                        };

            return await query.FirstOrDefaultAsync();
        }
    }
}
