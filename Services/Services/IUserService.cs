using Domain.DTOs;

namespace Services.Services
{
    public interface IUserService
    {
        Task<UserDTO> DeleteAsync(int id);
        Task<UserDTO> GetUserByUserName(string userName);
        Task<UserDTO> Register(RegisterDTO registerDTO);
        Task RegisterCustomer(RegisterCustomerDTO registerCustomerDTO);
        Task<bool> ValidateUserExist(string userName);
    }
}