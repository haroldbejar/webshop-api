using Domain.Builder;
using Domain.Data;
using Domain.Models;

namespace Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(WebShopContext context) : base(context) { }
        
        // Create and add relations of ProductCategory
        public async Task InsertProductWithCategory(Product product, List<int> categoryIds)
        {
            await _context.Products.AddAsync(product);

            foreach (var categoryId in categoryIds) 
            {
                var productCategory = new ProductCategory
                {
                    Product = product,
                    CategoryId = categoryId
                };
               await _context.ProductCategories.AddAsync(productCategory);
            }

            await _context.SaveChangesAsync();
        }
    }
}
