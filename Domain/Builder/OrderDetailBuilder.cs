using Domain.Models;

namespace Domain.Builder
{
    public class OrderDetailBuilder : BaseBuilder<OrderDetail>
    {
        public OrderDetailBuilder WithOrderDetailId(int orderDetailId) { _entity.OrderDetailId = orderDetailId; return this; }
        public OrderDetailBuilder WithOrderId(int orderId) { _entity.OrderId = orderId; return this; }
        public OrderDetailBuilder WithOrder(Order order) { _entity.Order = order; return this; }
        public OrderDetailBuilder WithProductId(int productId) { _entity.ProductId = productId; return this; }
        public OrderDetailBuilder WithProduct(Product product) { _entity.Product = product; return this; }
        public OrderDetailBuilder WithQuantity(int quantity) { _entity.Quantity = quantity; return this; }
    }
}
