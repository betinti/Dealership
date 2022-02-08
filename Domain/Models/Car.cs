using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Car : BaseModel
    {
        [StringLength(20)]
        [Required(ErrorMessage = ("Chassis is required in user"))]
        public string Chassis { get; set; }

        [Required(ErrorMessage = ("Model is required in user"))]
        public Model Model { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = ("Color is required in user"))]
        public string Color { get; set; }

        [Required(ErrorMessage = ("Value is required in user"))]
        public double Value { get; set; }

        [Required(ErrorMessage = ("Mileage is required in user"))]
        public double Mileage { get; set; }

        public Accessory? Accessory { get; set; }

        [Required(ErrorMessage = ("Sistem Version is required in user"))]
        public int SistemVersion { get; set; }

        public Owner? Owner { get; set; }

        [StringLength(10)]
        [MinLength(7)]
        public string? LicensePlate { get; set; }

        [StringLength(15)]
        [MinLength(10)]
        public string? Renavam { get; set; }

    }
}