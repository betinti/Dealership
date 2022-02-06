using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User : BaseModel
    {
        [Required(ErrorMessage = "Addres is required in user")]
        public Address Address { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Name is required in user")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "E-mail is required in user")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required in user")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "DDD is required in user")]
        public int DDD { get; set; }

        [StringLength(14)]
        [MinLength(11)]

        [Required(ErrorMessage = "Cpf or Cnpj is required in user")]
        public string CpfCnpj { get; set; }

        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }



    }


}