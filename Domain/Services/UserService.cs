using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Domain.DTO;

namespace Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly new IUserRepository _userRepository;
        private readonly new ILazyService _lazyService;

        public UserService(IUserRepository repository, ILazyService lazyService) : base(repository)
        {
            _userRepository = repository;
            _lazyService = lazyService;
        }

        public User CreateWithCreateds(UserDTO request, int addressId)
        {
            var user = request.ToSimpleModel();

            user.Address = _lazyService.Get<IAddressService>().Get(addressId);

            return Create(user);
        }
    }
}