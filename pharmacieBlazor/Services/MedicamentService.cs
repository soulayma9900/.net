using pharmacieBlazor.Models;
using System.Net.Http.Json;

namespace pharmacieBlazor.Services
{
    public class MedicamentService : IMedicamentService

    {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private const string ApiUrl = "api/Medicament";

        public MedicamentService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }

        public async Task<List<MedicamentDto>> GetAllAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<MedicamentDto>>(ApiUrl);
                return result ?? new List<MedicamentDto>();
            }
            catch (Exception ex)
            {
                _toastService.ShowError($"Erreur lors de la récupération des médicaments: {ex.Message}");
                return new List<MedicamentDto>();
            }
        }
        public async Task<MedicamentDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<MedicamentDto>($"{ApiUrl}/{id}");
            }
            catch (Exception ex)
            {
                _toastService.ShowError($"Erreur lors de la récupération du médicament: {ex.Message}");
                return null;
            }
        }

        public async Task<MedicamentDto> CreateAsync(MedicamentDto medicament)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiUrl, medicament);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<MedicamentDto>();
                _toastService.ShowSuccess("Médicament créé avec succès!");
                return result!;
            }
            catch (Exception ex)
            {
                _toastService.ShowError($"Erreur lors de la création: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(MedicamentDto medicament)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(ApiUrl, medicament);
                response.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("Médicament mis à jour avec succès!");
            }
            catch (Exception ex)
            {
                _toastService.ShowError($"Erreur lors de la mise à jour: {ex.Message}");
                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
                response.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("Médicament supprimé avec succès!");
            }
            catch (Exception ex)
            {
                _toastService.ShowError($"Erreur lors de la suppression: {ex.Message}");
                throw;
            }
        }
    }
}