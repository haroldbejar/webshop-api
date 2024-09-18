using System.Security.Cryptography;
using System.Text;
using Domain.DTOs;
using Domain.Models;
using Repository.Repositories;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IUserRepository _userRepository;

         public UserService(
            IRepository<User> repository, 
            IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public Task<UserDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetUserByUserName(string userName)
        {
           var user = await _userRepository.GetUserByUserName(userName);
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                Role = user.Role
            };
        }

        public async Task<UserDTO> Register(RegisterDTO registerDTO)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = registerDTO.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSalt = hmac.Key,
                Role = registerDTO.Role
            };

            await _repository.AddAsync(user);

            return new UserDTO
            {
                UserName = registerDTO?.UserName
            };
        }

        public async Task RegisterCustomer(RegisterCustomerDTO registerCustomerDTO)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = registerCustomerDTO.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerCustomerDTO.Password)),
                PasswordSalt = hmac.Key,
                Role = registerCustomerDTO.Role
            };

            await _repository.AddAsync(user);

            var customer = new Customer
            {
                Name = registerCustomerDTO.Name,
                Email = registerCustomerDTO.Email,
                Address = registerCustomerDTO.Address,
                UserId = user.Id
            };
        }

        public async Task<bool> ValidateUserExist(string userName)
        {
             var existingUser = await _userRepository.GetUserByUserName(userName);
            if (existingUser != null) return true;

            return false;
        }
    }
}