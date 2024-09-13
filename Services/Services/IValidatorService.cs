namespace Services.Services
{
    public interface IValidatorService<T> where T : class
    {
        Task<bool> EntityValidationAsync(int id);
    }
}