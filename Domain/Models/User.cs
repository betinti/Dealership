using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User : BaseModel
    {
        public Address Address { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Phone { get; set; }

        public int DDD { get; set; }

        [StringLength(18)]
        [MinLength(11)]
        public string CpfCnpj { get; set; }

        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }



    }


}