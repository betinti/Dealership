using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        IQueryable<Car> GetByMileage(double mileage);
        IQueryable<Car> GetByMileageRange(double startMiliage, double endMiliage);

        IQueryable<Car> GetBySistemVersion(int sistemVersion);
        IQueryable<Car> GetBySistemVersionRange(int startSistemVersion, int endSistemVersion);

    }
}