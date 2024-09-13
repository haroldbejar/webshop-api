using Domain.DTOs;
using Domain.Models;

namespace Services.Services
{
    public interface IOrderDetailService
    {
       Task<int> CountOrderDetailsAsync();
        Task DeleteOrderDetialAsync(int id);
        Task<IReadOnlyCollection<OrderDetailDTO>> GetAllOrderDetialsAsync(int pageNumber, int pageSize);
        Task<OrderDetailDTO> GetByOrderDetailIdAsync(int id);
        Task<IReadOnlyCollection<OrderDetailDTO>> GetDetailsByOrderId(int orderId);
        Task<IReadOnlyCollection<OrderDetailDTO>> GetDetailsByProductId(int productId);
        Task InsertOrderDetialAsync(OrderDetailDTO orderDetailDTO);
        Task UpdateOrderDetialAsync(OrderDetailDTO orderDetailDTO);
    }
}