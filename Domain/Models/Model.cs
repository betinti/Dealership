using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Model : BaseModel
    {
        [StringLength(20)]
       // [Required(ErrorMessage = "The brand of a model is required")]
        public string Brand { get; set; }

        //[Required(ErrorMessage = "The year of a model is required")]
        public int ModelYear { get; set; }

        //[Required(ErrorMessage = "The manufactore year of a model is required")]
        public int ManufactureYear { get; set; }

        [StringLength(100)]
        //[Required(ErrorMessage = "The description of a model is required")]
        public string ModelDescription { get; set; }
        public string? Engine { get; set; }
        public int? GearsCount { get; set; }
        public int? PassagersCount { get; set; }
        public int? HorsesPower { get; set; }
        public int? GrossWeight { get; set; }


    }
}