using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(DealershipContext context) : base(context)
        {
        }

        public Sale LastSaleFromSellerId(int sellerId)
        {
            return _dbSet.Where(s => s.Seller.Id == sellerId).OrderBy(s => s.BuyDate).FirstOrDefault();
        }
    }
}