using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services
{
    public class ModelService : BaseService<Model>, IModelService   
    {
        private readonly new IModelRepository _modelRepository;

        public ModelService(IModelRepository repository) : base(repository)
        {
            _modelRepository = repository;
        }

        


    }
}