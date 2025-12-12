using project.Models;

namespace project.Repositories
{
    public interface IMedicamentRepository
    {

        // Récupérer tous les médicaments
        Task<IEnumerable<Medicament>> GetAllAsync();
        Task<Medicament> GetByIdAsync(int id);
        Task AddAsync(Medicament medicament);
        Task UpdateAsync(Medicament medicament);
        Task DeleteAsync(int id);
    }
}
