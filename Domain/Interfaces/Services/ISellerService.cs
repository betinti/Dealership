using Domain.DTO;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ISellerService : IBaseService<Seller>
    {
        void UpdateMonthlyCommission(Sale sale);
        Seller CreateSeller(SellerDTO request);
        double GetTotalSalary(int id);
        double GetTotalSalaryByMonth(int id, int month);
    }
}