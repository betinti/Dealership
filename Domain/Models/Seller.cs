using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Seller : BaseModel
    {
        public double BaseSalary { get; set; }

        public double MonthlyCommission { get; set; }

        public int UserId { get; set; }
        
    }
}