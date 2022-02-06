namespace Domain.Interfaces.Services
{
    public interface ILazyService
    {
        T Get<T>();
    }
}