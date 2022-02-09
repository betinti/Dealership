using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Model : BaseModel
    {
        [StringLength(20)]
        public string Brand { get; set; }

        public int ModelYear { get; set; }

        public int ManufactureYear { get; set; }

        [StringLength(100)]
        public string ModelDescription { get; set; }
        public string? Engine { get; set; }
        public int? GearsCount { get; set; }
        public int? PassagersCount { get; set; }
        public int? HorsesPower { get; set; }
        public int? GrossWeight { get; set; }


    }
}