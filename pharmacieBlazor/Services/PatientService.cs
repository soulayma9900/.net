using pharmacieBlazor.Models;
using System.Net.Http.Json;

namespace pharmacieBlazor.Services
{
    public class PatientService : IPatientService
    {
        {
        private readonly HttpClient _httpClient;
        private readonly IToastService _toastService;
        private const string ApiUrl = "api/Patient";

        public PatientService(HttpClient httpClient, IToastService toastService)
        {
            _httpClient = httpClient;
            _toastService = toastService;
        }
        public async Task<List<PatientDto>> GetAllAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<PatientDto>>(ApiUrl);
                return result ?? new List<PatientDto>();
            }
            catch (Exception ex)
            {
                _toastService.ShowError($"Erreur: {ex.Message}");
                return new List<PatientDto>();
            }
        }

        public async Task<PatientDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PatientDto>($"{ApiUrl}/{id}");
            }
            catch (Exception ex)
            {
                _toastService.ShowError($"Erreur: {ex.Message}");
                return null;
            }
        }

        public async Task<PatientDto> CreateAsync(PatientDto patient)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ApiUrl, patient);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<PatientDto>();
                _toastService.ShowSuccess("Patient créé avec succès!");
                return result!;
            }
            catch (Exception ex)
            {
                _toastService.ShowError($"Erreur: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(PatientDto patient)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(ApiUrl, patient);
                response.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("Patient mis à jour!");
            }

            catch (Exception ex)
            {
                _toastService.ShowError($"Erreur: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");
                response.EnsureSuccessStatusCode();
                _toastService.ShowSuccess("Patient supprimé!");
            }
            catch (Exception ex)
            {
                _toastService.ShowError($"Erreur: {ex.Message}");
                throw;
            }
        }
    }
}






















    }
}
