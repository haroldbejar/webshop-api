using Domain.Models;

namespace Domain.Builder
{
    public class ProductCategoryBuilder : BaseBuilder<ProductCategory>
    {
        public ProductCategoryBuilder WithProductId(int productId) { _entity.ProductId = productId; return this; }
        public ProductCategoryBuilder WithProduct(Product product) { _entity.Product = product; return this;  }
        public ProductCategoryBuilder WithCategoryId(int categoryId) { _entity.CategoryId = categoryId; return this; }
        public ProductCategoryBuilder WithCategory(Category category) { _entity.Category = category; return this; }
    }
}
