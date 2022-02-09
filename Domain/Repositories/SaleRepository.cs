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

        public virtual Sale GetFilled(int id)
            => _dbSet.Where(s => s.Id == id)
                    .Include(s => s.Car).ThenInclude(c => c.Model)
                    .Include(s => s.Seller)
                    .Include(s => s.Owner).ThenInclude(o => o.User)
                    .FirstOrDefault();

        public IQueryable<Sale> GetBySellerAndMonth(int sellerId, int month)
            => _dbSet.Where(s => s.Seller.Id == sellerId && s.BuyDate.Month == month);
    }
}