using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class AccessoryRepository : BaseRepository<Accessory>, IAccessoryRepository
    {
        public AccessoryRepository(DealershipContext context) : base(context)
        {
        }
    }

}
