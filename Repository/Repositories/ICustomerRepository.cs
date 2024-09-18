using Domain.DTOs;

namespace Repository.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerDTO> GetCustomerByUserId(int userId);
    }
}
