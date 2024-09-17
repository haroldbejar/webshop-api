using AutoMapper;
using Domain.Builder;
using Domain.DTOs;
using Domain.Models;
using Repository.Repositories;

namespace Services.Services
{
    public class ProductService : IProductService, IValidatorService<OrderDetail>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public ProductService(
            IMapper mapper, 
            IRepository<Product> repository, 
            IProductRepository productRepository,
            IOrderDetailRepository orderDetailRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _productRepository = productRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        
        public async Task<bool> EntityValidationAsync(int id) 
        {
            var orderDetail = await _orderDetailRepository.GetDetailsByProductId(id);
            if (orderDetail.Count() == 0) return false;
            return true;
        }

        public async Task<int> CountProductAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) throw new ArgumentException("Product not found!");
            await _repository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<ProductDTO>> GetAllProductsAsync(int pageNumber, int pageSize)
        {
            var products = await _repository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetByProductIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task InsertProductAsync(ProductDTO productDto)
        {
            var producto = _mapper.Map<Product>(productDto);
            var productBuilder = new ProductBuilder()
                .WithProductId(producto.ProductId)
                .WithProductCode(producto.ProductCode)
                .WithProductName(producto.ProductName)
                .WithPrice(producto.Price)
                .WithStock(producto.Stock)
                .WithImageUrl(producto.ImageUrl)
                .WithDescription(producto.Description)
                .Build();
                
            await _repository.AddAsync(productBuilder);
        }

        public async Task InsertProductWithCategory(ProductDTO productDto, List<int> categoryIds) 
        {
            var producto = _mapper.Map<Product>(productDto);
            var productBuilder = new ProductBuilder()
                .WithProductId(producto.ProductId)
                .WithProductCode(producto.ProductCode)
                .WithProductName(producto.ProductName)
                .WithPrice(producto.Price)
                .WithStock(producto.Stock)
                .WithImageUrl(producto.ImageUrl)
                .WithDescription(producto.Description)
                .Build();

            await _productRepository.InsertProductWithCategory(productBuilder, categoryIds);
        }

        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var existingProduct = await _repository.GetByIdAsync(productDto.ProductId);
            if (existingProduct == null) throw new ArgumentException("Product not found!");
            existingProduct.ProductCode = productDto.ProductCode;
            existingProduct.ProductName = productDto.ProductName;
            existingProduct.Price = productDto.Price;
            existingProduct.Stock = productDto.Stock;
            existingProduct.ImageUrl = productDto.ImageUrl;
            existingProduct.Description = productDto.Description;

            await _repository.UpdateAsync(existingProduct);
        }
    }
}