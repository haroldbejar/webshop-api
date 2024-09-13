using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        
        public UserRepository(WebShopContext context) : base(context) { }
        public async Task<User> GetUserByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
