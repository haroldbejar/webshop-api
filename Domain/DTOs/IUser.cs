namespace Domain.DTOs
{
    public interface IUser
    {
        int Id { get; set;  }
        string UserName { get; set; }
        string Password { get; set; }
        string Role {  get; set; }
    }
}