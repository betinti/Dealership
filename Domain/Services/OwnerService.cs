using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services
{
    public class OwnerService : BaseService<Owner>, IOwnerService   
    {
        private readonly new IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository repository) : base(repository)
        {
            _ownerRepository = repository;
        }

        public override Owner Create<OwnerDTO>(OwnerDTO request)
        {
            throw new NotImplementedException();
        }


    }
}