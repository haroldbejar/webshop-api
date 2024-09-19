using AutoMapper;
using Domain.Builder;
using Domain.DTOs;
using Domain.Models;
using Repository.Repositories;

namespace Services.Services
{
    public class OrderService : IOrderService, IValidatorService<OrderDetail>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Order> _repository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(
            IMapper mapper, 
            IRepository<Order> repository, 
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<bool> EntityValidationAsync(int id)
        {
            var orderDetail = await _orderDetailRepository.GetDetailsByOrderId(id);
            if (orderDetail.Count() == 0) return false;
            return true;
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

        public async Task<OrderDTO> InsertOrderAsync(OrderDTO orderDTO)
        {
            if (orderDTO == null || orderDTO.OrderDetails == null || !orderDTO.OrderDetails.Any())
            {
                throw new ArgumentException("Order or OrderDetails cannot be null");
            }
            var order = _mapper.Map<Order>(orderDTO);
            var orderBuilder = new OrderBuilder()
                .WithCustomerId(order.CustomerId)
                .WithCustomer(order.Customer)
                .WithDescription(order.Description)
                .WithOrderDate(order.OrderDate)
                .Build();

            var createdOrder = await _orderRepository.InsertOrder(orderBuilder);
            // await _repository.AddAsync(orderBuilder);

            foreach ( var detail in order.OrderDetails) 
            {
                detail.OrderId = createdOrder.OrderId;
            }

            await _orderRepository.InsertOrderDetails(order.OrderDetails);

            var createdOrderDTO = _mapper.Map<OrderDTO>(createdOrder);

            return createdOrderDTO;
                
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