using AutoMapper;
using Domain.Builder;
using Domain.DTOs;
using Domain.Models;
using Repository.Repositories;

namespace Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _repository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IRepository<Order> repository, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _orderRepository = orderRepository;
        }

        public async Task<int> CountOrdersAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null) throw new ArgumentException("Order not found!");
            await _repository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<OrderDTO>> GetAllOrdersAsync(int pageNumber, int pageSize)
        {
             var orders = await _repository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetByOrderIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<IReadOnlyCollection<OrderDTO>> GetOrderByCustomerIdAsync(int customerId)
        {
            var orders = await _orderRepository.GetOrderByCustomerIdAsync(customerId);
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task InsertOrderAndDetails(List<OrderDetailsViewModel> orderDetails)
        {
            await _orderRepository.InsertOrderWithDetails(orderDetails);
        }

        public async Task InsertOrderAsync(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            var orderBuilder = new OrderBuilder()
                .WithCustomerId(order.CustomerId)
                .WithCustomer(order.Customer)
                .WithDescription(order.Description)
                .WithOrderDate(order.OrderDate)
                .Build();
            await _repository.AddAsync(orderBuilder);
                
        }

        public async Task UpdateOrderAsync(OrderDTO orderDTO)
        {
            var existingOrder = await _repository.GetByIdAsync(orderDTO.OrderId);
            if (existingOrder == null) throw new ArgumentException("Order not found!");

            existingOrder.CustomerId = orderDTO.CustomerId;
            existingOrder.Description = orderDTO.Description;
            existingOrder.OrderDate = orderDTO.OrderDate;


            await _repository.UpdateAsync(existingOrder);
        }
    }
}