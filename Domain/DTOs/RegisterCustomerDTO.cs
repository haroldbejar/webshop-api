namespace Domain.DTOs 
{
    public class RegisterCustomerDTO : IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}