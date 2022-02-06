using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(DealershipContext context) : base(context)
        {
        }

        public IQueryable<Car> GetAllFilled()
            => Get().Include(c => c.Owner).Include(c => c.Accessory).Include(c => c.Model);

        public IQueryable<Car> GetByMileage(double mileage)
            => GetAllFilled().Where(c => c.Mileage == mileage);

        public IQueryable<Car> GetByMileageRange(double startMiliage, double endMiliage)
            => GetAllFilled().Where(c => c.Mileage >= startMiliage).Where(c => c.Mileage <= endMiliage);

        public IQueryable<Car> GetBySistemVersion(int sistemVersion)
         => GetAllFilled().Where(c => c.SistemVersion == sistemVersion);

        public IQueryable<Car> GetBySistemVersionRange(int startSistemVersion, int endSistemVersion)
            => GetAllFilled().Where(c => c.SistemVersion >= startSistemVersion).Where(c => c.SistemVersion <= endSistemVersion);
    }
}