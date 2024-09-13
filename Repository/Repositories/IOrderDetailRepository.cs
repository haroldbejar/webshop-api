using Domain.Models;

namespace Repository.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IReadOnlyCollection<OrderDetail>> GetDetailsByOrderId(int orderId);
        Task<IReadOnlyCollection<OrderDetail>> GetDetailsByProductId(int productId);
    }
}
