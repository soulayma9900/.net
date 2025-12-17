using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Ordonnance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
<<<<<<< HEAD
        
        public int PharmacienId { get; set; }
        [ForeignKey(nameof(PharmacienId))]
        public Pharmacien? Pharmacien { get; set; }
=======

        // Simple string - PAS de clé étrangère ni navigation property!
        [Required]
        public string PharmacienId { get; set; }  // Juste l'ID, pas de relation

>>>>>>> c584dda784870006b67316603a0b4e330c6c288a

        [Required]
        public int PatientId { get; set; }
<<<<<<< HEAD
        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }
=======
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
>>>>>>> c584dda784870006b67316603a0b4e330c6c288a

        public List<Medicament> Medicaments { get; set; } = new List<Medicament>();
    }
}
