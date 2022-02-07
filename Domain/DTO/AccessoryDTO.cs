

using Domain.Models;

namespace Domain.DTO
{
    public class AccessoryDTO : BaseDTO<Accessory, AccessoryDTO>
    {
        public double Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override AccessoryDTO FromModel(Accessory model)
        {
            if (model == null)
                return null;

            this.Id = model.Id;
            this.Value = model.Value;
            this.Name = model.Name;
            this.Description = model.Description;

            return this;
        }

        public override Accessory ToModel()
        {
            return new Accessory
            {
                Value = this.Value,
                Name = this.Name,
                Description = this.Description
            };
        }
    }
}