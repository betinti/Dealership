using Domain.Enumerations;
using Domain.Exception;
using Domain.Models;

namespace Domain.DTO
{
    public class CarDTO : BaseDTO<Car, CarDTO>
    {
        public string Chassis { get; set; }

        public ModelDTO? Model { get; set; }

        public string Color { get; set; }

        public double? Value { get; set; }

        public double? Mileage { get; set; }

        public AccessoryDTO? Accessory { get; set; }

        public int? SystemVersion { get; set; }

        public OwnerDTO? Owner { get; set; }

        public string? LicensePlate { get; set; }

        public string? Renavam { get; set; }

        public override CarDTO FromModel(Car model)
        {
            if (model == null)
                return null;

            try
            {
                this.Id = model.Id;
                this.Chassis = model.Chassis;
                this.Model = new ModelDTO().FromModel(model.Model);
                this.Color = model.Color;
                this.Value = model.Value;
                this.Mileage = model.Mileage;
                this.Accessory = new AccessoryDTO().FromModel(model.Accessory);
                this.SystemVersion = model.SystemVersion;
                this.Owner = new OwnerDTO().FromModel(model.Owner);
                this.LicensePlate = model.LicensePlate;
                this.Renavam = model.Renavam;
            }
            catch (ApplicationException e)
            {
                throw new BaseException(ErrorType.ParseError, e);
            }

            return this;
        }

        public override Car ToSimpleModel()
        {

            if (this.Chassis == null)
                throw new BaseException("Chassis is required in user");

            if (this.Color == null)
                throw new BaseException("Color is required in user");

            if (!this.Value.HasValue)
                throw new BaseException("Value is required in user");

            if (!this.Mileage.HasValue)
                throw new BaseException("Mileage is required in user");

            if (!this.SystemVersion.HasValue)
                throw new BaseException("Sistem Version is required in user");

            return new Car
            {
                Id = this.Id.HasValue ? this.Id.Value : 0,
                Chassis = this.Chassis,
                Color = this.Color,
                Value = this.Value.HasValue ? this.Value.Value : 0,
                Mileage = this.Mileage.HasValue ? this.Mileage.Value : 0,
                SystemVersion = this.SystemVersion.HasValue ? this.SystemVersion.Value : 0,
            };
        }

        public override Car ToModel()
        {
            var car = ToSimpleModel();

            if ((this.LicensePlate != null && this.Renavam == null) || (this.LicensePlate == null && this.Renavam != null))
                throw new BaseException("The duo LicensePlate and Renavam are required");

            if (this.Renavam != null && this.Renavam.Length < 10)
                throw new BaseException("Car Renavam is lower than 10 characters");
            else if (this.Renavam != null && this.Renavam.Length > 15)
                throw new BaseException("Car Renavam is bigger than 15 characters");

            if (this.Model == null)
                throw new BaseException("Model is required in user");

            car.Model = this.Model != null ? this.Model.ToModel() : null;
            car.Accessory = this.Accessory != null ? this.Accessory.ToModel() : null;
            car.Owner = this.Owner != null ? this.Owner.ToModel() : null;
            car.LicensePlate = this.LicensePlate;
            car.Renavam = this.Renavam;

            return car;
        }

    }
}