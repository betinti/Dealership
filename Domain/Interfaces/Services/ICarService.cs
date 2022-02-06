using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ICarService : IBaseService<Car>
    {
        List<Car> GetByMileage(double mileage);
        List<Car> GetByMileageRange(double startMiliage, double endMiliage);
        List<Car> GetBySistemVersion(int sistemVersion);
        List<Car> GetBySistemVersionRange(int startSistemVersion, int endSistemVersion);
    }
}