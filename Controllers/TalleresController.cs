using API_TallerCapacitacion_SW.Models;
using API_TallerCapacitacion_SW.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_TallerCapacitacion_SW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalleresController : ControllerBase
    {
        private readonly ITallerRepository _tallerRepository;
        public TalleresController(ITallerRepository tallerRepository)
        {
            _tallerRepository = tallerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTalleres()
        {
            var talleres = await _tallerRepository.GetTalleresAsync();
            return Ok(talleres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaller(int id)
        {
            var taller = await _tallerRepository.GetTallerByIdAsync(id);
            if (taller == null)
                return NotFound();

            return Ok(taller);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTaller([FromBody] Taller taller)
        {
            // Implementar la lógica para validar el taller, cupo máximo, etc.
            // ...

            await _tallerRepository.AddTallerAsync(taller);
            return CreatedAtAction(nameof(GetTaller), new { id = taller.Id }, taller);
        }

        [HttpPost("{id}/asistencia")]
        public IActionResult RegistrarAsistencia(int id, [FromBody] Asistencia asistencia)
        {
            // Implementar la lógica para registrar la asistencia
            // ...

            return Ok("Asistencia registrada con éxito.");
        }



    }
}
