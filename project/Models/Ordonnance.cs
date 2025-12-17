using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Ordonnance
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        
        public int PharmacienId { get; set; }
        [ForeignKey(nameof(PharmacienId))]
        public Pharmacien? Pharmacien { get; set; }

        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }

        // Relation 1 ordonnance → plusieurs médicaments
        public List<Medicament> Medicaments { get; set; } = new List<Medicament>();
    }
}
