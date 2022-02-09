using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Domain.DTO;
using Domain.Exception;

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

        public Seller CreateSeller(SellerDTO request)
        {
            if (request.User == null)
                throw new BaseException("User is required to create an seller");

            var user = _lazyService.Get<IUserService>().Create<UserDTO>(request.User);

            var model = request.ToSimpleModel();

            if (user == null)
                throw new BaseException("Não foi possível criar o usuário para o vendedor");

            model.UserId = user.Id;

            return _sellerRepository.Create(model);
        }

    }
}