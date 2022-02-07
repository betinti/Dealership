using Domain.Models;

namespace Domain.DTO
{
    public class SellerDTO : BaseDTO<Seller, SellerDTO>
    {
        public double BaseSalary { get; set; }
        public double MonthlyCommission { get; set; }
        public UserDTO User { get; set; }

        public override SellerDTO FromModel(Seller model)
        {
            if (model == null)
                return null;

            this.Id = model.Id;
            this.BaseSalary = model.BaseSalary;
            this.MonthlyCommission = model.MonthlyCommission;

            return this;
        }

        public override Seller ToModel()
        {
            return new Seller
            {
                BaseSalary = this.BaseSalary,
                MonthlyCommission = this.MonthlyCommission,
            };
        }
    }
}