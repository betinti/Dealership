using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Car : BaseModel
    {
        [StringLength(20)]
        public string Chassis { get; set; }

        public Model? Model { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        public double Value { get; set; }

        public double Mileage { get; set; }

        public Accessory? Accessory { get; set; }

        public int SystemVersion { get; set; }

        public Owner? Owner { get; set; }

        [StringLength(10)]
        [MinLength(7)]
        public string? LicensePlate { get; set; }

        [StringLength(15)]
        [MinLength(10)]
        public string? Renavam { get; set; }

    }
}