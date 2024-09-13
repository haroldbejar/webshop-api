using Domain.DTOs;

namespace Services.Services
{
    public interface ICategoryService
    {
        Task<int> CountCategoryAsync();
        Task DeleteCategoryAsync(int id);
        Task<IReadOnlyCollection<CategoryDTO>> GetAllCatetoriesAsync(int pageNumber, int pageSize);
        Task<CategoryDTO> GetByCategoryIdAsync(int id);
        Task InsertCategoryAsync(CategoryDTO categoryDTO);
        Task UpdateCategoryAsync(CategoryDTO categoryDTO);
    }
}