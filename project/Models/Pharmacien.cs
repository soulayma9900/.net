using System.ComponentModel.DataAnnotations;
namespace project.Models
{
    public class Pharmacien
    {

        [Key]
        public int Id { get; set; }

        [Required]
       
        public string Nom { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        //pharmacien a plusiseurs ord
        public List<Ordonnance> Ordonnances { get; set; } = new List<Ordonnance>();
    }
}

