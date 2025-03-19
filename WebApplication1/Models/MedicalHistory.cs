using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class MedicalHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
