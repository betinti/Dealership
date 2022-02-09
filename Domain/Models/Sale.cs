using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Sale : BaseModel
    {
        public Car Car { get; set; }

        public Seller Seller { get; set; }

        public Owner Owner { get; set; }

        public double Price { get; set; }

        public double CommissionPercentage { get; set; }

        public DateTime BuyDate { get; set; }
    }
}