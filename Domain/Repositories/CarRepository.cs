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

        public IQueryable<Car> GetBySystemVersion(int systemVersion)
         => GetAllFilled().Where(c => c.SystemVersion == systemVersion);

        public IQueryable<Car> GetBySystemVersionRange(int startSystemVersion, int endSystemVersion)
            => GetAllFilled().Where(c => c.SystemVersion >= startSystemVersion).Where(c => c.SystemVersion <= endSystemVersion);

        public virtual Car GetFilled(int id)
            => _dbSet
                .Include(c => c.Owner).Include(c => c.Accessory).Include(c => c.Model)
                .Where(c => c.Id == id).FirstOrDefault();
    }
}