using System.Linq;
using Domain.Enumerations;
using Domain.Exception;
using Domain.Models;

namespace Domain.DTO
{
    public class OwnerDTO : BaseDTO<Owner, OwnerDTO>
    {
        public string CNH { get; set; }
        public UserDTO? User { get; set; }

        public override OwnerDTO FromModel(Owner model)
        {
            if (model == null)
                return null;

            try
            {
                this.Id = model.Id;
                this.CNH = model.CNH;
                this.User = new UserDTO().FromModel(model.User);
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.ParseError, e);
            }

            return this;
        }

        public override Owner ToSimpleModel()
        {
            if (this.CNH == null)
                throw new BaseException("CNH is required in user");
            else if (this.CNH.Length < 11)
                throw new BaseException("CNH is lower than 11 characters");

            return new Owner
            {
                CNH = this.CNH,
                Id = this.Id.HasValue ? this.Id.Value : 0
            };
        }

        public override Owner ToModel()
        {
            var owner = ToSimpleModel();

            if (this.User == null)
                throw new BaseException("Seller needs an user");

            owner.User = this.User.ToModel();

            return owner;
        }
    }
}
