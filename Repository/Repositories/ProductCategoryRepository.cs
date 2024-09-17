using Domain.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(WebShopContext context) : base(context) { }

        public async Task<IReadOnlyCollection<ProductCategoryDTO>> GetByCategoryId(int categoryId, int pageNumber, int pageSize)
        {
            var query = from pc in _context.ProductCategories
                        join p in _context.Products on pc.ProductId equals p.ProductId
                        join c in _context.Categories on pc.CategoryId equals c.CategoryId
                        where pc.CategoryId == categoryId
                        select new ProductCategoryDTO
                        {
                            ProductId = pc.ProductId,
                            ProductName = p.ProductName,
                            ProductCode = p.ProductCode,
                            Title = $"{p.ProductCode ?? ""} {p.ProductName ?? ""}",
                            Price = p.Price,
                            Stock = p.Stock,
                            ImageUrl = p.ImageUrl,
                            CategoryId = pc.CategoryId,
                            Name = c.Name,
                            Description = p.Description
                        };
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<ProductCategoryDTO>> GetByProductId(int productId, int pageNumber, int pageSize)
        {
             var query = from pc in _context.ProductCategories
                        join p in _context.Products on pc.ProductId equals p.ProductId
                        join c in _context.Categories on pc.CategoryId equals c.CategoryId
                        where p.ProductId == productId
                        select new ProductCategoryDTO
                        {
                            ProductId = pc.ProductId,
                            ProductName = p.ProductName,
                            ProductCode = p.ProductCode,
                            Title = $"{p.ProductCode ?? ""} {p.ProductName ?? ""}",
                            Price = p.Price,
                            Stock = p.Stock,
                            ImageUrl = p.ImageUrl,
                            CategoryId = pc.CategoryId,
                            Name = c.Name,
                            Description = p.Description
                        };
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
