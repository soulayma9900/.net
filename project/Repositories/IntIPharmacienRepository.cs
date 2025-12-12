using project.Models;

namespace project.Repositories
{
    public interface IntIPharmacienRepository
    {
        // Récupérer tous les pharmaciens
        Task<IEnumerable<Pharmacien>> GetAllAsync();
         
      
        Task<Pharmacien> GetByIdAsync(int id);

        Task AddAsync(Pharmacien pharmacien);
        
        Task UpdateAsync(Pharmacien pharmacien);
      
        Task DeleteAsync(int id);

        
        Task<Pharmacien> LoginAsync(string email, string password);

    }
}
