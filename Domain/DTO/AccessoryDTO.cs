

using Domain.Enumerations;
using Domain.Exception;
using Domain.Models;

namespace Domain.DTO
{
    public class AccessoryDTO : BaseDTO<Accessory, AccessoryDTO>
    {
        public double? Value { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public override AccessoryDTO FromModel(Accessory model)
        {
            if (model == null)
                return null;

            try
            {
                this.Id = model.Id;
                this.Value = model.Value;
                this.Name = model.Name;
                this.Description = model.Description;
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.ParseError, e);
            }

            return this;
        }

        public override Accessory ToModel()
        {
            if (!this.Value.HasValue)
                throw new BaseException("The value is required at Accessory");

            if (this.Name == null)
                throw new BaseException("The name of an Accessory is required");

            return new Accessory
            {
                Value = this.Value.HasValue ? this.Value.Value : 0,
                Name = this.Name,
                Description = this.Description,
                Id = this.Id.HasValue ? this.Id.Value : 0
            };
        }
    }
}