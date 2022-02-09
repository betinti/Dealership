using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Seller : BaseModel
    {
        //[Required(ErrorMessage = "BaseSalary is required in user")]
        public double BaseSalary { get; set; }

        //[Required(ErrorMessage = "MonthlyCommission is required in user")]
        public double MonthlyCommission { get; set; }

        //[Required(ErrorMessage = "Seller needs an user")]
        public int UserId { get; set; }
        
    }
}