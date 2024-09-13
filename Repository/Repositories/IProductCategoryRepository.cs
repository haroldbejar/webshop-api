using Domain.DTOs;

namespace Repository.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IReadOnlyCollection<ProductCategoryDTO>> GetByCategoryId(int categoryId, int pageNumber, int pageSize);
        Task<IReadOnlyCollection<ProductCategoryDTO>> GetByProductId(int productId, int pageNumber, int pageSize);
    }
}
