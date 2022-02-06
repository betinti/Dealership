using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Address : BaseModel
    {
        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(2)]
        public string UF { get; set; }

        [StringLength(10)]
        [MinLength(6)]
        [Required(ErrorMessage = "Address CEP needs is required")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Address number needs is required")]
        public int Number { get; set; }

        [StringLength(100)]
        public string? Complement { get; set; }

        [StringLength(100)]
        public string? Reference { get; set; }
    }


}