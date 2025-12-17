using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Repositories
{
    
        public class OrdonnanceRepository : IOrdonnanceRepository
        {
            private readonly PharmacieDbContext _context;

            public OrdonnanceRepository(PharmacieDbContext context)
            {
                _context = context;
            }


        public async Task<IEnumerable<Ordonnance>> GetAllAsync()
        {
            return await _context.Ordonnances
                .Include(o => o.Patient)
                .Include(o => o.Pharmacien)
                .Include(o => o.Medicaments)
                .ToListAsync();
        }

        public async Task<Ordonnance?> GetByIdAsync(int id)
        {
            return await _context.Ordonnances
                .Include(o => o.Patient)
                .Include(o => o.Pharmacien)
                .Include(o => o.Medicaments)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Ordonnance ordonnance)
        {
            await _context.Ordonnances.AddAsync(ordonnance);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Ordonnance ordonnance)
        {
            _context.Ordonnances.Update(ordonnance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ord = await _context.Ordonnances.FindAsync(id);
            if (ord == null) return;

            _context.Ordonnances.Remove(ord);
            await _context.SaveChangesAsync();
        }
    }
}