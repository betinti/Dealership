using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        IQueryable<Car> GetByMileage(double mileage);
        IQueryable<Car> GetByMileageRange(double startMiliage, double endMiliage);

        IQueryable<Car> GetBySystemVersion(int sistemVersion);
        IQueryable<Car> GetBySystemVersionRange(int startSistemVersion, int endSistemVersion);

    }
}