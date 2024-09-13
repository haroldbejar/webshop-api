using Domain.Models;

namespace Domain.Builder
{
    public class OrderBuilder : BaseBuilder<Order>
    {
        public OrderBuilder WithOrderId(int orderId) { _entity.OrderId = orderId; return this; }
        public OrderBuilder WithCustomerId(int customerId) {  _entity.CustomerId = customerId; return this; }
        public OrderBuilder WithCustomer(Customer customer) { _entity.Customer = customer; return this; }
        public OrderBuilder WithDescription(string description) { _entity.Description = description; return this; }
        public OrderBuilder WithOrderDate(DateTime orderDate) {  _entity.OrderDate = orderDate; return this; }
    }
}
