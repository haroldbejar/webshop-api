using Domain.Models;

namespace Repository.Repositories
{
    public interface IProductRepository
    {
        Task InsertProductWithCategory(Product product, List<int> categoryId);
    }
}
