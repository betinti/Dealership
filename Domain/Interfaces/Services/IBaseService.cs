using Domain.Models;
using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<TModel> : IDisposable where TModel : BaseModel
    {
        TModel Create(TModel model);
        // TModel Create<TResponse>(TResponse request)
        // where TResponse : BaseDTO<TModel, TResponse>;
        IEnumerable<TModel> Create(IEnumerable<TModel> models);

        IEnumerable<TModel> Get();
        TModel Get(int id);
        // IEnumerable<TResponse> Get<TResponse>()
        // where TResponse : BaseDTO<TModel, TResponse>, new();
        // TResponse Get<TResponse>(int id)
        // where TResponse : BaseDTO<TModel, TResponse>, new();
        IEnumerable<TModel> Get(IEnumerable<int> id);

        TModel Update(TModel model);
        // TModel Update<TResponse>(TResponse model)
        // where TResponse : BaseDTO<TModel, TResponse>, new();
        IEnumerable<TModel> Update(IEnumerable<TModel> models);
        // IEnumerable<TResponse> Update<TResponse>(IEnumerable<TResponse> models)
        // where TResponse : BaseDTO<TModel, TResponse>, new();

        TModel Delete(int id);
        TModel Delete(TModel model);
        IEnumerable<TModel> Delete(IEnumerable<TModel> models);
        // TModel Delete<TResponse>(TResponse model)
        // where TResponse : BaseDTO<TModel, TResponse>, new();
        // IEnumerable<TModel> Delete<TResponse>(IEnumerable<TResponse> models)
        // where TResponse : BaseDTO<TModel, TResponse>, new();




    }
}