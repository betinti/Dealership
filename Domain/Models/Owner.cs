using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Owner : BaseModel
    {
        [Required(ErrorMessage = "Seller needs an user")]
        public User User { get; set; }

        [StringLength(20)]
        [MinLength(11)]
        [Required(ErrorMessage = ("CNH is required in user"))]
        public string CNH { get; set; }


    }
}