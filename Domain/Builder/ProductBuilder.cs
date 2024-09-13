using Domain.Models;

namespace Domain.Builder
{
    public class ProductBuilder : BaseBuilder<Product>
    {
        public ProductBuilder WithProductId(int productId) { _entity.ProductId = productId; return this; }
        public ProductBuilder WithProductName(string productName) { _entity.ProductName = productName; return this; }
        public ProductBuilder WithProductCode(string productCode) { _entity.ProductCode = productCode; return this; }
        public ProductBuilder WithPrice(decimal price) { _entity.Price = price; return this; }
        public ProductBuilder WithStock(int stock) { _entity.Stock = stock; return this; }
        public ProductBuilder WithImageUrl(string imageUrl) { _entity.ImageUrl = imageUrl; return this; }
    }
}
