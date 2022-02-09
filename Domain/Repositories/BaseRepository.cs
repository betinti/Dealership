using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel>
     where TModel : BaseModel, new()
    {

        protected readonly DealershipContext _context;
        protected readonly DbSet<TModel> _dbSet;



        public BaseRepository(DealershipContext context)
        {
            _context = context;
            _dbSet = _context.Set<TModel>();
        }

        public virtual int Commit() => this._context.SaveChanges();

        public virtual TModel AfterCRUD(TModel model)
        {
            Commit();
            return model;
        }

        public TModel Create(TModel model)
        {
            this._dbSet.Add(model);

            return AfterCRUD(model);
        }

        public IEnumerable<TModel> Create(IEnumerable<TModel> models)
        {
            foreach (var model in models)
                this._dbSet.Add(model);
            this.Commit();
            return models;
        }

        public TModel Delete(TModel model)
        {
            this._dbSet.Remove(model);

            return AfterCRUD(model);
        }

        public TModel Delete(int id)
         => Delete(Get(id));



        public IQueryable<TModel> Get()
         => this._dbSet;

        public TModel Get(int id)
         => this._dbSet.Find(id);

        public TModel Update(TModel model)
        {
            // var entity = Get(model.Id);
            _dbSet.Update(model);

            return AfterCRUD(model);
        }

        public IEnumerable<TModel> Update(IEnumerable<TModel> models)
        {
            foreach (var model in models)
                this._dbSet.Update(model);
            this.Commit();
            return models;
        }

        public virtual void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TModel GetFilled(int id)
            => Get(id);

        public IEnumerable<TModel> Delete(IEnumerable<TModel> models)
        {
            foreach (var model in models)
                this._dbSet.Remove(model);
            this.Commit();
            return models;
        }
    }
}