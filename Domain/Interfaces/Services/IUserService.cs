using Domain.DTO;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        User CreateWithCreateds(UserDTO request, int addressId);
    }
}