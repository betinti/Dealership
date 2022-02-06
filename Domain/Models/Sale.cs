using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Sale : BaseModel
    {
        [Required(ErrorMessage = "Car in an sale is required")]
        public Car Car { get; set; }

        [Required(ErrorMessage = "Seller in an sale is required")]
        public Seller Seller { get; set; }

        [Required(ErrorMessage = "Owner in an sale is required")]
        public Owner Owner { get; set; }

        [Required(ErrorMessage = "Price in an sale is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The Commission Percentage in an sale is required")]
        public double CommissionPercentage { get; set; }

        [Required(ErrorMessage = "Date in an sale is required")]
        public DateTime BuyDate { get; set; }
    }
}