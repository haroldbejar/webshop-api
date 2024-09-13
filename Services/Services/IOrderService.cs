using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Services.Services
{
    public interface IOrderService
    {
        Task<int> CountOrdersAsync();
        Task DeleteOrderAsync(int id);
        Task<IReadOnlyCollection<OrderDTO>> GetAllOrdersAsync(int pageNumber, int pageSize);
        Task<OrderDTO> GetByOrderIdAsync(int id);
        Task<IReadOnlyCollection<OrderDTO>> GetOrderByCustomerIdAsync(int customerId);
        Task InsertOrderAndDetails(List<OrderDetailsViewModel> orderDetails);
        Task InsertOrderAsync(OrderDTO orderDTO);
        Task UpdateOrderAsync(OrderDTO orderDTO);
    }
}