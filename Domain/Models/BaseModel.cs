using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            EntityId = System.Guid.NewGuid();
        }

        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? EntityId { get; set; }
    }
}