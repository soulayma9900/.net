using System.ComponentModel.DataAnnotations;

namespace project.DTO
{
    public class OrdonnanceDTOs
    {
<<<<<<< HEAD
      //  public int Id { get; set; }
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public int PharmacienId { get; set; }

        // Liste des médicaments liés à l’ordonnance
        public List<int> MedicamentIds { get; set; } = new();
=======
        public int Id { get; set; }

        [Required(ErrorMessage = "La date est requise")]
        public DateTime Date { get; set; }

        // Pas Required car sera rempli automatiquement par le système
        public string? PharmacienId { get; set; }  // ← CHANGÉ de int à string + nullable
        public string? PharmacienNom { get; set; }  // ← AJOUTÉ pour affichage

        [Required(ErrorMessage = "L'ID du patient est requis")]
        public int PatientId { get; set; }

        public List<int> MedicamentIds { get; set; } = new List<int>();
>>>>>>> c584dda784870006b67316603a0b4e330c6c288a
    }
}
