using Domain.Models;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;
using Domain.Exception;
using Domain.DTO;
using Domain.Enumerations;

namespace Domain.Services
{
    public class SaleService : BaseService<Sale>, ISaleService
    {
        private readonly double commissionPercentage = 0.01;
        private readonly new ISaleRepository _saleRepository;
        private readonly new ILazyService _lazyService;

        public SaleService(ISaleRepository repository, ILazyService lazyService) : base(repository)
        {
            _saleRepository = repository;
            _lazyService = lazyService;
        }

        public List<Sale> GetBySellerAndMonth(int sellerId, int month)
        {
            var sales = _saleRepository.GetBySellerAndMonth(sellerId, month).ToList();

            if (sales == null || sales.Count == 0)
                throw new BaseException(ErrorType.AnyFound);

            return sales;
        }

        public Sale LastSaleFromSellerId(int sellerId)
        {
            var response = new Sale();

            response = _saleRepository.LastSaleFromSellerId(sellerId);

            return BeforeComplete(response, ErrorType.AnyFound);
        }

        public Sale NewSaleById(BuyCarDTO buyCar)
        {
            var sellerService = _lazyService.Get<ISellerService>();
            var carService = _lazyService.Get<ICarService>();

            var car = carService.Get(buyCar.CarId);

            if (car == null)
                throw new BaseException("Não foi possível encontrar o carro", buyCar.CarId.ToString());

            var seller = sellerService.Get(buyCar.SellerId);

            if (seller == null)
                throw new BaseException("Não foi possível encontrar o vendedor", buyCar.SellerId.ToString());

            var owner = _lazyService.Get<IOwnerService>().Get(buyCar.OwnerId);

            if (owner == null)
                throw new BaseException("Não foi possível encontrar o comprador", buyCar.OwnerId.ToString());

            car.Owner = owner;

            var sale = new Sale
            {
                Car = car,
                Seller = seller,
                Owner = owner,
                Price = buyCar.Price,
                CommissionPercentage = commissionPercentage,
                BuyDate = DateTime.Now
            };

            sale = Create(sale);

            carService.Update(car);

            sellerService.UpdateMonthlyCommission(sale);

            return sale;
        }
    }
}