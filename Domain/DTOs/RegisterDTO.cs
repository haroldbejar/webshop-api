namespace Domain.DTOs
{
    public class RegisterDTO : IUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
