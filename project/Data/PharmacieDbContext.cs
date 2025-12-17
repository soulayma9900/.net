using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using project.Models;

namespace project.Data
{
    public class PharmacieDbContext : DbContext
    {
        public PharmacieDbContext(DbContextOptions<PharmacieDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Ordonnance> Ordonnances { get; set; }
<<<<<<< HEAD
        public DbSet<Medicament> Medicaments { get; set; } 

=======
        public DbSet<Medicament> Medicaments { get; set; }
>>>>>>> c584dda784870006b67316603a0b4e330c6c288a
    }
}









