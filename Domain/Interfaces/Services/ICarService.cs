using Domain.DTO;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ICarService : IBaseService<Car>
    {
        Car CreateWithCreateds(CarDTO request, int modelId, int accessoryId, int ownerId);
        List<Car> GetByMileage(double mileage);
        List<Car> GetByMileageRange(double startMileage, double endMileage);
        List<Car> GetBySystemVersion(int systemVersion);
        List<Car> GetBySystemVersionRange(int startSystemVersion, int endSystemVersion);
        List<Car> GetBySystemVersionAndMileage(int systemVersion, double miliage);
    }
}