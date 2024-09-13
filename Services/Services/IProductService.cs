using Domain.DTOs;

namespace Services.Services
{
    public interface IProductService
    {
        Task<int> CountProductAsync();
        Task DeleteProductAsync(int id);
        Task<IReadOnlyCollection<ProductDTO>> GetAllProductsAsync(int pageNumber, int pageSize);
        Task<ProductDTO> GetByProductIdAsync(int id);
        Task InsertProductAsync(ProductDTO productDto);
        Task InsertProductWithCategory(ProductDTO productDto, List<int> categoryIds);
        Task UpdateProductAsync(ProductDTO productDto);
    }
}