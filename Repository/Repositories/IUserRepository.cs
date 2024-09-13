using Domain.Models;

namespace Repository.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserName(string userName);
    }
}
