using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Medicament
    {
        [Key]
        public int Id { get; set; }
         [Required]
        public string Nom { get; set; }
        [Required]
        public string Dosage { get; set; }
        // Relation avec Ordonnance
        public int OrdonnanceId { get; set; }
        [ForeignKey("OrdonnanceId")]
        public Ordonnance Ordonnance { get; set; }
    }
}
