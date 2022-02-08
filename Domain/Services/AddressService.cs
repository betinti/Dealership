using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services
{
    public class AddressService : BaseService<Address>, IAddressService   
    {
        private readonly new IAddressRepository _addressRepository;

        public AddressService(IAddressRepository repository) : base(repository)
        {
            _addressRepository = repository;
        }

    }
}