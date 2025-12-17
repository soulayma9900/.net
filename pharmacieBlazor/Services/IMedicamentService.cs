
using pharmacieBlazor.Models;

namespace pharmacieBlazor.Services
{
    public interface IMedicamentService
    {
        Task<List<MedicamentDto>> GetAllAsync();
        Task<MedicamentDto?> GetByIdAsync(int id);
        Task<MedicamentDto> CreateAsync(MedicamentDto medicament);
        Task UpdateAsync(MedicamentDto medicament);
        Task DeleteAsync(int id);
    }
}
