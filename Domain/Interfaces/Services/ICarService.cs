using Domain.DTO;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ICarService : IBaseService<Car>
    {
        Car CreateWithCreateds(CarDTO request, int modelId, int accessoryId, int ownerId);
        List<Car> GetByMileage(double mileage);
        List<Car> GetByMileageRange(double startMiliage, double endMiliage);
        List<Car> GetBySystemVersion(int sistemVersion);
        List<Car> GetBySystemVersionRange(int startSistemVersion, int endSistemVersion);
    }
}