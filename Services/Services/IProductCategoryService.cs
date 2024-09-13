using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Services.Services
{
    public interface IProductCategoryService
    {
        Task<int> CountProductCategoryAsync();
        Task DeleteProductCategoryAsync(int id);
        Task<IReadOnlyCollection<ProductCategoryDTO>> GetAllProductCategoryAsync(int pageNumber, int pageSize);
        Task<ProductCategoryDTO> GetProductCategoryByIdAsync(int id);
        Task<IReadOnlyCollection<ProductCategoryDTO>> GetByCategoryId(int categoryId, int pageNumber, int pageSize);
        Task<IReadOnlyCollection<ProductCategoryDTO>> GetByProductId(int productId, int pageNumber, int pageSize);
        Task InsertProductCategory(ProductCategoryDTO productCategoryDTO);
        Task UpdateProductCategory(ProductCategoryDTO productCategoryDTO);
    }
}