using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Accessory : BaseModel
    {
        [Required(ErrorMessage = "The value is required at Accessory")]
        public double Value { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "The name of an Accessory is required")]
        public string Name { get; set; }

        [StringLength(80)]
        public string Description { get; set; }
    }
}