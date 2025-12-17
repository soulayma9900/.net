using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.DTO;
using project.Models;
using project.Repositories;


namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdonnanceController : ControllerBase
    {

        private readonly IOrdonnanceRepository _repository;

        public OrdonnanceController(IOrdonnanceRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ordonnances = await _repository.GetAllAsync();

            var result = ordonnances.Select(o => new
            {
                o.Id,
                o.Date,
                o.PatientId,
                o.PharmacienId,
                MedicamentIds = o.Medicaments.Select(m => m.Id).ToList()
            });

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ordonnance = await _repository.GetByIdAsync(id);
            if (ordonnance == null)
                return NotFound("Ordonnance not found");

            return Ok(new
            {
                ordonnance.Id,
                ordonnance.Date,
                ordonnance.PatientId,
                ordonnance.PharmacienId,
                MedicamentIds = ordonnance.Medicaments.Select(m => m.Id).ToList()
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrdonnanceDTOs dto)
        {
            var ordonnance = new Ordonnance
            {
                Date = dto.Date,
                PatientId = dto.PatientId,
                PharmacienId = dto.PharmacienId,
                Medicaments = dto.MedicamentIds.Select(id => new Medicament { Id = id }).ToList()
            };

            await _repository.AddAsync(ordonnance);

            return CreatedAtAction(nameof(GetById), new { id = ordonnance.Id }, ordonnance.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrdonnanceDTOs dto)
        {
            var ordonnance = await _repository.GetByIdAsync(id);
            if (ordonnance == null)
                return NotFound("Ordonnance not found");

            ordonnance.Date = dto.Date;
            ordonnance.PatientId = dto.PatientId;
            ordonnance.PharmacienId = dto.PharmacienId;

            ordonnance.Medicaments.Clear();
            foreach (var medId in dto.MedicamentIds)
                ordonnance.Medicaments.Add(new Medicament { Id = medId });

            await _repository.UpdateAsync(ordonnance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ordonnance = await _repository.GetByIdAsync(id);
            if (ordonnance == null)
                return NotFound("Ordonnance not found");

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}