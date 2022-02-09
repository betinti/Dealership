using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(DealershipContext context) : base(context)
        {
        }

        public virtual Owner GetFilled(int id)
            => _dbSet.Where(o => o.Id == id)
                    .Include(o => o.User).ThenInclude(u => u.Address)
                    .FirstOrDefault();

    }
}