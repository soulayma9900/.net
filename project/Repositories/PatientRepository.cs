using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PharmacieDbContext _context;

        public PatientRepository(PharmacieDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            // On récupère les patients sans include
            var patients = await _context.Patients.ToListAsync();
            // Charger les ordonnances pour chaque patient
            foreach (var p in patients)
            {
                p.Ordonnances = await _context.Ordonnances
                                              .Where(o => o.PatientId == p.Id)
                                              .ToListAsync();
            }

            return patients;
        }
        // Récupérer un patient par ID
        // -----------------------------
        public async Task<Patient> GetByIdAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
                return null;
            // Charger ses ordonnances manuellement
            patient.Ordonnances = await _context.Ordonnances
                                                .Where(o => o.PatientId == id)
                                                .ToListAsync();

            return patient;
        }
        // ajout patient 
        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
