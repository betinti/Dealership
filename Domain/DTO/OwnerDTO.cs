using System.Linq;
using Domain.Enumerations;
using Domain.Exception;
using Domain.Models;

namespace Domain.DTO
{
    public class OwnerDTO : BaseDTO<Owner, OwnerDTO>
    {
        public string CNH { get; set; }
        public UserDTO User { get; set; }

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

        public override Owner ToModel()
        {
            return new Owner
            {
                CNH = this.CNH,
                User = this.User.ToModel(),
            };
        }
    }
}
