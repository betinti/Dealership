using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        IQueryable<Car> GetByMileage(double mileage);
        IQueryable<Car> GetByMileageRange(double startMileage, double endMileage);

        IQueryable<Car> GetBySystemVersion(int systemVersion);
        IQueryable<Car> GetBySystemVersionRange(int startSistemVersion, int endSistemVersion);

        IQueryable<Car> GetBySystemVersionAndMileage(int systemVersion, double miliage);

    }
}