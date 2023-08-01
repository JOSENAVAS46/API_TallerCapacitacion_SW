using API_TallerCapacitacion_SW.Models;
using API_TallerCapacitacion_SW.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_TallerCapacitacion_SW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private readonly IParticipanteRepository _participanteRepository;

        public ParticipantesController(IParticipanteRepository participanteRepository)
        {
            _participanteRepository = participanteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetParticipantes()
        {
            var participantes = await _participanteRepository.GetParticipantesAsync();
            return Ok(participantes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipante(int id)
        {
            var participante = await _participanteRepository.GetParticipanteByIdAsync(id);
            if (participante == null)
                return NotFound();

            return Ok(participante);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarParticipante([FromBody] Participante participante)
        {
            // Implementar la lógica para validar el participante, verificar si ya existe, etc.
            // ...

            await _participanteRepository.AddParticipanteAsync(participante);
            return CreatedAtAction(nameof(GetParticipante), new { id = participante.Id }, participante);
        }


    }
}
