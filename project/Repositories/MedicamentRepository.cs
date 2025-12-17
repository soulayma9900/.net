using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Repositories
{
    public class MedicamentRepository : IMedicamentRepository
    {

        private readonly PharmacieDbContext _context;

        public MedicamentRepository(PharmacieDbContext context)
        {
            _context = context;
        }


        // Récupérer tous les médicaments
        public async Task<IEnumerable<Medicament>> GetAllAsync()
        {
            return await _context.Medicaments.ToListAsync();
        }

        // Récupérer un médicament par ID
        public async Task<Medicament> GetByIdAsync(int id)
        {
            return await _context.Medicaments.FindAsync(id);
        }

        // Ajouter un médicament
        public async Task AddAsync(Medicament medicament)
        {
            await _context.Medicaments.AddAsync(medicament);
             await _context.SaveChangesAsync();
        }


        // Mettre à jour un médicament
        public async Task UpdateAsync(Medicament medicament)
        {
            _context.Medicaments.Update(medicament);
            await _context.SaveChangesAsync();
        }

        // Supprimer un médicament
        public async Task DeleteAsync(int id)
        {
            var medicament = await _context.Medicaments.FindAsync(id);
            if (medicament != null)
            {
                _context.Medicaments.Remove(medicament);
                await _context.SaveChangesAsync();
            }
        }
    }
}