using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(DealershipContext context) : base(context)
        {
        }

        public virtual Address GetFilled(int id)
            => Get(id);
    }
}