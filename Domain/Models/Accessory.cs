using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Accessory : BaseModel
    {
        public double Value { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(80)]
        public string? Description { get; set; }
    }
}