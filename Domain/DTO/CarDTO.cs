using Domain.Models;

namespace Domain.DTO
{
    public class CarDTO : BaseDTO<Car, CarDTO>
    {
        public string Chassis { get; set; }

        public ModelDTO Model { get; set; }

        public string Color { get; set; }

        public double Value { get; set; }

        public double Mileage { get; set; }

        public AccessoryDTO? Accessory { get; set; }

        public int SistemVersion { get; set; }

        public OwnerDTO? Owner { get; set; }

        public string? LicensePlate { get; set; }

        public string? Renavam { get; set; }

        public CarDTO FromModel(Car model)
        {
            if (model == null)
                return null;

            this.Id = model.Id;
            this.Chassis = model.Chassis;
            this.Model = new ModelDTO().FromModel(model.Model);
            this.Color = model.Color;
            this.Value = model.Value;
            this.Mileage = model.Mileage;
            this.Accessory = new AccessoryDTO().FromModel(model.Accessory);
            this.SistemVersion = model.SistemVersion;
            this.Owner = new OwnerDTO().FromModel(model.Owner);
            this.LicensePlate = model.LicensePlate;
            this.Renavam = model.Renavam;

            return this;
        }

        public Car ToModel()
        {
            return new Car
            {
                Chassis = this.Chassis,
                Model = this.Model.ToModel(),
                Color = this.Color,
                Value = this.Value,
                Mileage = this.Mileage,
                Accessory = this.Accessory.ToModel(),
                SistemVersion = this.SistemVersion,
                Owner = this.Owner.ToModel(),
                LicensePlate = this.LicensePlate,
                Renavam = this.Renavam,
            };

        }

    }
}