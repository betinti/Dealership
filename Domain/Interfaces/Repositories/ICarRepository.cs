using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        IQueryable<Car> GetByMileage(double mileage);
        IQueryable<Car> GetBySistemVersion(int sistemVersion);
    }
}