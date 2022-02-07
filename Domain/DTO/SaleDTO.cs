using Domain.Models;

namespace Domain.DTO
{
    public class SaleDTO : BaseDTO<Sale, SaleDTO>
    {
        public CarDTO Car { get; set; }
        public SellerDTO Seller { get; set; }
        public OwnerDTO Owner { get; set; }
        public double Price { get; set; }
        public double CommissionPercentage { get; set; }

        public override SaleDTO FromModel(Sale model)
        {
            if (model == null)
                return null;

            this.Id = model.Id;
            this.Car = new CarDTO().FromModel(model.Car);
            this.Seller = new SellerDTO().FromModel(model.Seller);
            this.Owner = new OwnerDTO().FromModel(model.Owner);
            this.Price = model.Price;
            this.CommissionPercentage = model.CommissionPercentage;

            return this;
        }

        public override Sale ToModel()
        {
            return new Sale
            {
                Car = this.Car.ToModel(),
                Seller = this.Seller.ToModel(),
                Owner = this.Owner.ToModel(),
                Price = this.Price,
                CommissionPercentage = this.CommissionPercentage
            };
        }
    }
}