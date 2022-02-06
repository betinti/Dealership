using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ISellerService : IBaseService<Seller>
    {
        void UpdateMonthlyCommission(Sale sale);
    }
}