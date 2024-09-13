using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Builder;
using Domain.DTOs;
using Domain.Models;
using Repository.Repositories;

namespace Services.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ProductCategory> _repository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(
            IMapper mapper,
            IRepository<ProductCategory> repository,
            IProductCategoryRepository productCategoryRepository

            )
        {
            _mapper = mapper;
            _repository = repository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<int> CountProductCategoryAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            var productCategory = await _repository.GetByIdAsync(id);
            if (productCategory == null) throw new ArgumentException("The resource doesn't exist!");
            await _repository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<ProductCategoryDTO>> GetAllProductCategoryAsync(int pageNumber, int pageSize)
        {
            var productCategories = await _repository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<List<ProductCategoryDTO>>(productCategories);
        }

        public async Task<IReadOnlyCollection<ProductCategoryDTO>> GetByCategoryId(int categoryId, int pageNumber, int pageSize)
        {
            var productsCategory = await _productCategoryRepository.GetByCategoryId(categoryId, pageNumber, pageSize);    
            return _mapper.Map<List<ProductCategoryDTO>>(productsCategory);
        }

        public async Task<IReadOnlyCollection<ProductCategoryDTO>> GetByProductId(int productId, int pageNumber, int pageSize)
        {
            var productsCategory = await _productCategoryRepository.GetByProductId(productId,pageNumber,pageSize);
            return _mapper.Map<List<ProductCategoryDTO>>(productsCategory);
        }

        public async Task<ProductCategoryDTO> GetProductCategoryByIdAsync(int id)
        {
            var productCategoty = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductCategoryDTO>(productCategoty);
        }

        public async Task InsertProductCategory(ProductCategoryDTO productCategoryDTO)
        {
            var productCategory = _mapper.Map<ProductCategory>(productCategoryDTO);
            var productCategoryBuilder = new ProductCategoryBuilder()
                .WithProductId(productCategory.ProductId)
                .WithProduct(productCategory.Product)
                .WithCategoryId(productCategory.CategoryId)
                .WithCategory(productCategory.Category)
                .Build();
                
            await _repository.AddAsync(productCategoryBuilder);
        }

        public async Task UpdateProductCategory(ProductCategoryDTO productCategoryDTO)
        {
             var existingProductCategory = await _repository.GetByIdAsync(productCategoryDTO.ProductId);
            if (existingProductCategory == null) throw new ArgumentException("ProductCategory doesn´t exist!");

            existingProductCategory.ProductId = productCategoryDTO.ProductId;
            existingProductCategory.CategoryId = productCategoryDTO.CategoryId;

            await _repository.UpdateAsync(existingProductCategory);
        }
    }
}