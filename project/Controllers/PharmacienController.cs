using Microsoft.AspNetCore.Mvc;
using project.DTO;
using project.Models;
using project.Repositories;
using System;

namespace project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PharmacienController : ControllerBase
    {
        private readonly IntIPharmacienRepository _repository;

        public PharmacienController(IntIPharmacienRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Pharmacien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PharmacienDTOs>>> GetAll()
        {
            var pharmaciens = await _repository.GetAllAsync();
            var dtos = pharmaciens.Select(p => new PharmacienDTOs
            {
                Id = p.Id,
                Nom = p.Nom,
                Email = p.Email
                // Password n'est pas exposé
            }).ToList();

            return Ok(dtos);
        }

        // GET: api/Pharmacien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PharmacienDTOs>> GetById(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p == null) return NotFound();

            var dto = new PharmacienDTOs
            {
                Id = p.Id,
                Nom = p.Nom,
                Email = p.Email
            };

            return Ok(dto);
        }

        // POST: api/Pharmacien
        [HttpPost]
        public async Task<ActionResult<PharmacienDTOs>> Create([FromBody] PharmacienDTOs dto)
        {
            var pharmacien = new Pharmacien
            {
                Nom = dto.Nom,
                Email = dto.Email,
                Password = dto.Password
            };

            await _repository.AddAsync(pharmacien);

            var resultDto = new PharmacienDTOs
            {
                Id = pharmacien.Id,
                Nom = pharmacien.Nom,
                Email = pharmacien.Email
            };

            return CreatedAtAction(nameof(GetById), new { id = pharmacien.Id }, resultDto);
        }

        // PUT: api/Pharmacien/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PharmacienDTOs dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Nom = dto.Nom;
            existing.Email = dto.Email;
            if (!string.IsNullOrEmpty(dto.Password))
            {
                existing.Password = dto.Password;
            }

            await _repository.UpdateAsync(existing);
            return NoContent();
        }

        // DELETE: api/Pharmacien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }

        // POST: api/Pharmacien/login
        [HttpPost("login")]
        public async Task<ActionResult<PharmacienDTOs>> Login([FromBody] PharmacienDTOs dto)
        {
            var user = await _repository.LoginAsync(dto.Email, dto.Password);
            if (user == null) return Unauthorized();

            var resultDto = new PharmacienDTOs
            {
                Id = user.Id,
                Nom = user.Nom,
                Email = user.Email
            };

            return Ok(resultDto);
        }
    }
}
