using Domain.Models;

namespace Domain.Builder
{
    public class CustomerBuilder : BaseBuilder<Customer>
    {
        public CustomerBuilder WithCustomerId(int customerId) { _entity.CustomerId = customerId; return this; }
        public CustomerBuilder WithName(string name) { _entity.Name = name; return this; }
        public CustomerBuilder WithEmail(string email) { _entity.Email = email; return this; }
    }
}
