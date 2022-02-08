using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DealershipContext context) : base(context)
        {
        }

        public virtual User GetFilled(int id)
            => _dbSet.Where(u => u.Id == id)
                    .Include(u => u.Address)
                    .FirstOrDefault();

    }
}