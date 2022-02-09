using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services
{
    public class AccessoryService : BaseService<Accessory>, IAccessoryService
    {
        private readonly new IAccessoryRepository _accessoryRepository;

        public AccessoryService(IAccessoryRepository repository) : base(repository)
        {
            _accessoryRepository = repository;
        }
    }
}