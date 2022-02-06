using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ICarService : IBaseService<Car>
    {
        List<Car> GetByMileage(double mileage);
        List<Car> GetBySistemVersion(int sistemVersion);
    }
}