using AutoMapper;
using Domain.Builder;
using Domain.DTOs;
using Domain.Models;
using Repository.Repositories;

namespace Services.Services
{
    public class CustomerService : ICustomerService, IValidatorService<Order>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _repository;
        private readonly ICustomerRepository _customerRepository;
         private readonly IOrderRepository _orderRepository;

        public CustomerService(IMapper mapper, IRepository<Customer> repository, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _customerRepository = customerRepository;
        }

        public async Task<bool> EntityValidationAsync(int id)
        {   
            var order = await _orderRepository.GetOrderByCustomerIdAsync(id);
            if (order.Count() == 0) return false;
            return true;
        }

        public async Task<int> CountCustomerAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null) throw new ArgumentException("Customer not found!");
            await _repository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<CustomerDTO>> GetAllCustomersAsync(int pageNumber, int pageSize)
        {
            var customers = await _repository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<List<CustomerDTO>>(customers);
        }

        public async Task<CustomerDTO> GetByCustomerIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> GetCustomerByUserId(int userId)
        {
            var customer = await _customerRepository.GetCustomerByUserId(userId);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task InsertCustomerAsync(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var customerBuilder = new CustomerBuilder()
                .WithCustomerId(customer.CustomerId)
                .WithName(customer.Name)
                .WithEmail(customer.Email)
                .Build();

            await _repository.AddAsync(customerBuilder);
        }

        public async Task UpdateCustomerAsync(CustomerDTO customerDTO)
        {
            var existingCustomer = await _repository.GetByIdAsync(customerDTO.CustomerId);
            if (existingCustomer == null) throw new ArgumentException("Customer not found!");
            existingCustomer.Name = customerDTO.Name;
            existingCustomer.Email = customerDTO.Email;

            await _repository.UpdateAsync(existingCustomer);
        }
    }
}