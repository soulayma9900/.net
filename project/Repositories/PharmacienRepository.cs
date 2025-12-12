using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Repositories
{
    public class PharmacienRepository : IntIPharmacienRepository

    {
        private readonly PharmacieDbContext _context;
       //constructeur : injection db context 
        public PharmacienRepository(PharmacieDbContext context)
        {
            _context = context;
        }
        // Récupérer tous les pharmaciens
        public async Task<IEnumerable<Pharmacien>> GetAllAsync()
        {
            return await _context.Pharmaciens.ToListAsync();
        }
        // Récupérer un pharmacien par son ID
        public async Task<Pharmacien> GetByIdAsync(int id)
        {
            return await _context.Pharmaciens.FindAsync(id);
        }

        // Ajouter un pharmacien
        public async Task AddAsync(Pharmacien pharmacien)
        {
            await _context.Pharmaciens.AddAsync(pharmacien);
            await _context.SaveChangesAsync();
        }
        // Mettre à jour un pharmacien
        public async Task UpdateAsync(Pharmacien pharmacien)
        {
            _context.Pharmaciens.Update(pharmacien);
            await _context.SaveChangesAsync();
        }

        // Supprimer un pharmacien
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Pharmaciens.FindAsync(id);
            if (entity != null)
            {
                _context.Pharmaciens.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Authentification (Login)
        public async Task<Pharmacien> LoginAsync(string email, string password)
        {
            return await _context.Pharmaciens
                .FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
        }
    }
}