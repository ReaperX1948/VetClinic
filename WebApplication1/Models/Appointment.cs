using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [ForeignKey("Pet")]
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
