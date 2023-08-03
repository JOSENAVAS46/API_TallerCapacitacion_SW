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
        public async Task<IActionResult> ObtenerParticipantes()
        {
            var participantes = await _participanteRepository.GetParticipantesAsync();
            return Ok(participantes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerParticipanteById(int id)
        {
            var participante = await _participanteRepository.GetParticipanteByIdAsync(id);
            if (participante == null)
                return NotFound();

            return Ok(participante);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarParticipante([FromBody] Participante participante)
        {
            // Verificar si el modelo recibido es válido
            if (!ModelState.IsValid)
                return BadRequest("Datos del participante inválidos.");

            // Verificar si el participante ya existe (por ejemplo, utilizando el email)
            var participanteExistente = await _participanteRepository.GetParticipantesAsync();
            if (participanteExistente.Any(p => p.Email.ToLower() == participante.Email.ToLower()))
                return Conflict("El participante ya está registrado.");

            await _participanteRepository.AddParticipanteAsync(participante);
            return CreatedAtAction(nameof(ObtenerParticipanteById), new { id = participante.Id }, participante);
        }


    }
}
