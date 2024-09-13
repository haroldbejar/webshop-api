using Domain.DTOs;

namespace Services.Services
{
    public interface ICustomerService
    {
        Task<int> CountCustomerAsync();
        Task DeleteCustomerAsync(int id);
        Task<IReadOnlyCollection<CustomerDTO>> GetAllCustomersAsync(int pageNumber, int pageSize);
        Task<CustomerDTO> GetByCustomerIdAsync(int id);
        Task InsertCustomerAsync(CustomerDTO customerDTO);
        Task UpdateCustomerAsync(CustomerDTO customerDTO);
    }
}