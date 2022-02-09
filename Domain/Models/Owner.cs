using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Owner : BaseModel
    {
        public User User { get; set; }

        [StringLength(20)]
        [MinLength(11)]
        public string CNH { get; set; }


    }
}