using System.ComponentModel.DataAnnotations;

namespace project.DTO
{
    public class MedicamentDTOs
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du médicament est requis")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le dosage du médicament est requis")]
        public string Dosage { get; set; }

        [Required(ErrorMessage = "L'ID de l'ordonnance est requis")]
        public int OrdonnanceId { get; set; }
    }
}
