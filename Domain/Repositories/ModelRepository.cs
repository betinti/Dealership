using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class ModelRepository : BaseRepository<Model>, IModelRepository
    {
        public ModelRepository(DealershipContext context) : base(context)
        {
        }

        public virtual Model GetFilled(int id)
            => Get(id);

    }
}