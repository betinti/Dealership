using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Sale LastSaleFromSellerId(int sellerId);
    }
}