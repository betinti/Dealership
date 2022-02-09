using Domain.DTO;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ISaleService : IBaseService<Sale>
    {
        Sale NewSaleById(BuyCarDTO buyCar);
        Sale LastSaleFromSellerId(int sellerId);
        List<Sale> GetBySellerAndMonth(int sellerId, int month);
    }
}