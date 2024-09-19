using Domain.DTOs;
using Domain.Models;

namespace Repository.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyCollection<Order>> GetOrderByCustomerIdAsync(int customerId);
        Task<Order> InsertOrder(Order order);
        Task InsertOrderDetails(IEnumerable<OrderDetail> orderDetials);
    }
}
