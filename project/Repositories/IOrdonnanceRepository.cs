using project.Models;

namespace project.Repositories
{
 
        public interface IOrdonnanceRepository
        {
            Task<IEnumerable<Ordonnance>> GetAllAsync();
            Task<Ordonnance?> GetByIdAsync(int id);
            Task AddAsync(Ordonnance ordonnance);
            Task UpdateAsync(Ordonnance ordonnance);
            Task DeleteAsync(int id);
        }
    }
