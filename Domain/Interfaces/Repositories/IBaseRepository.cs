using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TModel> : IDisposable where TModel : BaseModel
    {
        TModel Create(TModel model);

        IQueryable<TModel> Get();
        TModel Get(int id);

        TModel Update(TModel model);

        TModel Delete(TModel model);
        
        TModel Delete(int id);


    }
}