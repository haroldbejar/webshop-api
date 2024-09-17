namespace Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
        public int? UserId { get; set; }
        public User User {get; set;}
    }
}
