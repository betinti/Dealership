using Domain.Enumerations;
using Domain.Exception;
using Domain.Models;

namespace Domain.DTO
{
    public class SaleDTO : BaseDTO<Sale, SaleDTO>
    {
        public CarDTO Car { get; set; }
        public SellerDTO Seller { get; set; }
        public OwnerDTO Owner { get; set; }
        public double? Price { get; set; }
        public double? CommissionPercentage { get; set; }
        public DateTime BuyDate { get; set; }


        public override SaleDTO FromModel(Sale model)
        {
            if (model == null)
                return null;

            try
            {
                this.Id = model.Id;
                this.Car = new CarDTO().FromModel(model.Car);
                this.Seller = new SellerDTO().FromModel(model.Seller);
                this.Owner = new OwnerDTO().FromModel(model.Owner);
                this.Price = model.Price;
                this.CommissionPercentage = model.CommissionPercentage;
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.ParseError, e);
            }

            return this;
        }

        public override Sale ToModel()
        {
            if (this.Car == null)
                throw new BaseException("Car in an sale is required");

            if (this.Seller == null)
                throw new BaseException("Seller in an sale is required");

            if (this.Owner == null)
                throw new BaseException("Owner in an sale is required");

            if (!this.Price.HasValue)
                throw new BaseException("Price in an sale is required");

            if (!this.CommissionPercentage.HasValue)
                throw new BaseException("The Commission Percentage in an sale is required");

            if (this.BuyDate == null)
                throw new BaseException("Date in an sale is required");

            return new Sale
            {
                Car = this.Car.ToModel(),
                Seller = this.Seller.ToModel(),
                Owner = this.Owner.ToModel(),
                Price = this.Price.HasValue ? this.Price.Value : 0,
                CommissionPercentage = this.CommissionPercentage.HasValue ? this.CommissionPercentage.Value : 0,
                Id = this.Id.HasValue ? this.Id.Value : 0
            };
        }
    }
}