using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TModel> : IDisposable where TModel : BaseModel
    {
        TModel Create(TModel model);
        IEnumerable<TModel> Create(IEnumerable<TModel> models);

        IQueryable<TModel> Get();
        TModel Get(int id);

        TModel Update(TModel model);
        IEnumerable<TModel> Update(IEnumerable<TModel> models);

        TModel Delete(TModel model);
        IEnumerable<TModel> Delete(IEnumerable<TModel> models);

        TModel Delete(int id);

        TModel GetFilled(int id);

    }
}