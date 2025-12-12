using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        
        public string Nom { get; set; }

        public DateTime DateNaissance { get; set; }
        //patient a plusieurs ordonance 
        public List<Ordonnance> Ordonnances { get; set; } = new List<Ordonnance>();
    
    }
}  
