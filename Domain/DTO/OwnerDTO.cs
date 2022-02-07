using System.Linq;
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

            this.Id = model.Id;
            this.CNH = model.CNH;
            this.User = new UserDTO().FromModel(model.User);

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
