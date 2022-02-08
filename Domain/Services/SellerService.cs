using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services
{
    public class SellerService : BaseService<Seller>, ISellerService
    {
        private readonly new ISellerRepository _sellerRepository;
        private readonly ILazyService _lazyService;

        public SellerService(ISellerRepository repository, ILazyService lazyService) : base(repository)
        {
            _sellerRepository = repository;
            _lazyService = lazyService;
        }

        public override Seller Create<SellerDTO>(SellerDTO request)
        {
            throw new NotImplementedException();
        }

        public void UpdateMonthlyCommission(Sale sale)
        {
            var seller = sale.Seller;

            var saleDate = sale.BuyDate;

            var lastSaleDate = _lazyService.Get<ISaleService>().LastSaleFromSellerId(seller.Id).BuyDate;

            if (saleDate.Month == lastSaleDate.Month && saleDate.Year == lastSaleDate.Year)
                seller.MonthlyCommission = seller.MonthlyCommission + (sale.CommissionPercentage * sale.Price);
            else if (saleDate.Month > lastSaleDate.Month && saleDate.Year == lastSaleDate.Year)
                seller.MonthlyCommission = sale.CommissionPercentage * sale.Price;


            Update(seller);
        }

    }
}