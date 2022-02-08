using Domain.Enumerations;
using Domain.Exception;
using Domain.Models;

namespace Domain.DTO
{
    public class SellerDTO : BaseDTO<Seller, SellerDTO>
    {
        public double BaseSalary { get; set; }
        public double MonthlyCommission { get; set; }
        public UserDTO? User { get; set; }
        public int? UserId { get; set; }

        public override SellerDTO FromModel(Seller model)
        {
            if (model == null)
                return null;

            try
            {
                this.Id = model.Id;
                this.BaseSalary = model.BaseSalary;
                this.MonthlyCommission = model.MonthlyCommission;
                this.User = new UserDTO { Id = model.Id };
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.ParseError, e);
            }

            return this;
        }

        public override Seller ToModel()
        {
            return new Seller
            {
                BaseSalary = this.BaseSalary,
                MonthlyCommission = this.MonthlyCommission,
                UserId = (this.User.Id.HasValue ? this.User.Id.Value : 0)
            };
        }
    }
}