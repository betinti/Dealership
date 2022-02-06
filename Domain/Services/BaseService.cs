using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Enumerations;
using Domain.Exception;

namespace Domain.Services
{
    public abstract class BaseService<TModel> : IBaseService<TModel> where TModel : BaseModel, new()
    {
        protected readonly IBaseRepository<TModel> _repository;

        public BaseService(IBaseRepository<TModel> repository)
        {
            _repository = repository;
        }

        public void Dispose()
            => _repository.Dispose();

        public TModel BeforeComplete(TModel model, ErrorType action)
        {
            if (model == null)
                throw new BaseException(action);
            return model;
        }

        public TModel Create(TModel model)
        {
            var result = new TModel();
            try
            {
                result = _repository.Create(model);
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.CantCreate, e);
            }

            return BeforeComplete(result, ErrorType.CantCreate);
        }

        // public TModel Create<TResponse>(TResponse request)
        //     => Create(request.ToModel());

        public IEnumerable<TModel> Create(IEnumerable<TModel> models)
        {
            List<TModel> createds = new List<TModel>();
            try
            {
                foreach (var model in models)
                {
                    var result = Create(model);
                    if (result == null)
                        throw new BaseException(ErrorType.CantCreate);
                    createds.Add(result);
                }
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.CantCreate, e);
            }

            return createds;
        }

        public TModel Delete(int id)
        {
            var result = new TModel();
            try
            {
                result = _repository.Delete(Get(id));
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.CantDelete, e, id.ToString());
            }

            return BeforeComplete(result, ErrorType.CantDelete);
        }

        public TModel Delete(TModel model)
        {
            var result = new TModel();
            try
            {
                result = _repository.Delete(model);
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.CantDelete, e, model.Id.ToString());
            }

            return BeforeComplete(result, ErrorType.CantDelete);
        }

        public IEnumerable<TModel> Delete(IEnumerable<TModel> models)
        {
            List<TModel> deleteds = new List<TModel>();
            var idE = "";

            try
            {
                foreach (var model in models)
                {
                    var result = Delete(model);
                    idE = model.Id.ToString();
                    if (result == null)
                        throw new BaseException(ErrorType.CantDelete, idE);
                    deleteds.Add(result);
                }
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.CantDelete, e, idE);
            }

            return deleteds;
        }

        public IEnumerable<TModel> Get()
        {
            var result = new List<TModel>();
            try
            {
                result = _repository.Get().ToList();
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.AnyFound, e);
            }
            if (result == null || result.Count == 0)
                throw new BaseException(ErrorType.AnyFound);
            return result;
        }

        public TModel Get(int id)
        {
            var result = new TModel();
            try
            {
                result = _repository.Get(id);
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.NotFound, e, id.ToString());
            }

            if (result == null)
                throw new BaseException(ErrorType.NotFound, id.ToString());

            return result;
        }

        public IEnumerable<TModel> Get(IEnumerable<int> id)
        {
            List<TModel> readeds = new List<TModel>();
            var idE = "";

            try
            {
                foreach (var identifier in id)
                {
                    var result = Get(identifier);
                    idE = identifier.ToString();
                    if (result == null)
                        throw new BaseException(ErrorType.NotFound, idE);
                    readeds.Add(result);
                }
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.AnyFound, e, idE);
            }

            return readeds;
        }

        public TModel Update(TModel model)
        {
            var result = new TModel();
            try
            {
                result = _repository.Update(model);
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.CantUpdate, e, model.Id.ToString());
            }
            return BeforeComplete(result, ErrorType.CantCreate);
        }

        public IEnumerable<TModel> Update(IEnumerable<TModel> models)
        {
            List<TModel> updates = new List<TModel>();
            var idE = "";
            try
            {
                foreach (var model in models)
                {
                    idE = model.Id.ToString();
                    var result = Update(model);
                    if (result == null)
                        throw new BaseException(ErrorType.CantUpdate, idE);
                    updates.Add(result);
                }
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.CantUpdate, e, idE);
            }

            return updates;
        }
    }
}