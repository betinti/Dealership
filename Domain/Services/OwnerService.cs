using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Domain.DTO;

namespace Domain.Services
{
    public class OwnerService : BaseService<Owner>, IOwnerService
    {
        private readonly new IOwnerRepository _ownerRepository;
        private readonly new ILazyService _lazyService;

        public OwnerService(IOwnerRepository repository, ILazyService lazyService) : base(repository)
        {
            _ownerRepository = repository;
            _lazyService = lazyService;
        }

    }
}