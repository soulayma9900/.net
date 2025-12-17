using System.ComponentModel.DataAnnotations;

namespace pharmacieBlazor.Models
{
    public class OrdonnanceDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La date est requise")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Le patient est requis")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Le pharmacien est requis")]
        public int PharmacienId { get; set; }

        public List<int> MedicamentIds { get; set; } = new();
    }
}
