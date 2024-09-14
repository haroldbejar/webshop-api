using AutoMapper;
using Domain.Builder;
using Domain.DTOs;
using Domain.Models;
using Repository.Repositories;

namespace Services.Services
{
    public class CategoryService : ICategoryService, IValidatorService<ProductCategory>
    {
         private readonly IMapper _mapper;
        private readonly IRepository<Category> _repository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CategoryService(
            IMapper mapper, 
            IRepository<Category> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> EntityValidationAsync(int id)
        {
            int pageNumber = 1;
            int pageSize = 10;
            var productCategory = await _productCategoryRepository.GetByCategoryId(id, pageNumber, pageSize);
            if (productCategory.Count > 0) return true;
            return false;
        }

        public async Task<int> CountCategoryAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) throw new ArgumentException("Category not found!");
            await _repository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<CategoryDTO>> GetAllCatetoriesAsync(int pageNumber, int pageSize)
        {
            var categories = await _repository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetByCategoryIdAsync(int id)
        {
             var category = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task InsertCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            var categoryBuilder = new CategoryBuilder()
                .WithCategoryId(category.CategoryId)
                .WithName(category.Name)
                .Build();

            await _repository.AddAsync(categoryBuilder);
        }

        public async Task UpdateCategoryAsync(CategoryDTO categoryDTO)
        {
            var existingCategory = await _repository.GetByIdAsync(categoryDTO.CategoryId);
            if (existingCategory == null) throw new ArgumentException("Category not found!");
            existingCategory.CategoryId = categoryDTO.CategoryId;
            existingCategory.Name = categoryDTO.Name;

            await _repository.UpdateAsync(existingCategory);
        }
    }
}