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
        private readonly IAsistenciaRepository _asistenciaRepository;
        private readonly IParticipanteRepository _participanteRepository;
        public TalleresController(ITallerRepository tallerRepository, IAsistenciaRepository asistenciaRepository , IParticipanteRepository participanteRepository)
        {
            _tallerRepository = tallerRepository;
            _asistenciaRepository = asistenciaRepository;
            _participanteRepository = participanteRepository;

        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTalleres()
        {
            var talleres = await _tallerRepository.GetTalleresAsync();
            return Ok(talleres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTallerById(int id)
        {
            var taller = await _tallerRepository.GetTallerByIdAsync(id);
            if (taller == null)
                return NotFound();

            return Ok(taller);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTaller([FromBody] Taller taller)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos del taller inválidos.");

            var tallerExistente = await _tallerRepository.GetTalleresAsync();
            if (tallerExistente.Any(t => t.Nombre.ToLower() == taller.Nombre.ToLower()))
                return Conflict("El taller ya está registrado.");

            taller.FechaFin = taller.FechaInicio.AddHours(5);
            if (taller.CupoMaximo == 0 || taller.CupoMaximo == null)
            {
                taller.CupoMaximo = 10;
            }

            await _tallerRepository.AddTallerAsync(taller);
            return CreatedAtAction(nameof(ObtenerTallerById), new { id = taller.Id }, taller);
        }

        [HttpPut("{idTaller}/participantes")]
        public async Task<IActionResult> AgregarParticipanteATaller(int idTaller, [FromBody] int idParticipante )
        {
            Participante participante = null;
            // Verificar si el modelo recibido es válido
            if (!ModelState.IsValid)
                return BadRequest("Datos del participante inválidos.");

            // Buscar el taller al que se quiere agregar el participante
            var taller = await _tallerRepository.GetTallerByIdAsync(idTaller);
            if (taller == null)
                return NotFound("Taller no encontrado.");

            if (idParticipante == 0)
                return BadRequest("Id del participante inválido.");

            participante = await _participanteRepository.GetParticipanteByIdAsync(idParticipante);
            if (participante == null)
                return NotFound("Participante no encontrado.");

            // Verificar si el taller ya ha finalizado
            if (DateTime.Now > taller.FechaFin)
                return BadRequest("El taller ya ha finalizado, no se pueden agregar más participantes.");

            // Verificar si el taller ha alcanzado el cupo máximo de participantes
            if (taller.Participantes?.Count >= taller.CupoMaximo)
                return BadRequest("El taller ha alcanzado el cupo máximo de participantes.");

            // Agregar el participante a la lista de participantes del taller
            if (taller.Participantes == null)
                taller.Participantes = new List<Participante>();

            taller.Participantes.Add(participante);
            await _tallerRepository.UpdateTallerAsync(taller);

            // Guardar los cambios en la base de datos
            await _tallerRepository.SaveChangesAsync();

            return Ok($"Participante '{participante.Nombre} {participante.Apellido}' agregado al taller '{taller.Nombre}' correctamente.");
        }


        [HttpPost("{id}/asistencia")]
        public async Task<IActionResult> RegistrarAsistencia([FromBody] Asistencia asistencia)
        {
            // Verificar si el modelo recibido es válido
            if (!ModelState.IsValid)
                return BadRequest("Datos de la asistencia inválidos.");

            // Buscar el taller al que se quiere registrar la asistencia
            var taller = await _tallerRepository.GetTallerByIdAsync(asistencia.TallerId);
            if (taller == null)
                return NotFound("Taller no encontrado.");

            // Verificar si el taller ha terminado
            if (asistencia.FechaHora > taller.FechaFin)
                return BadRequest("El taller ya ha terminado, no se pueden registrar más asistencias.");

            // Verificar si el participante ya está inscrito en el taller
            var participante = taller.Participantes.FirstOrDefault(p => p.Id == asistencia.ParticipanteId);
            if (participante == null)
                return NotFound("El participante no está inscrito en este taller.");


            await _asistenciaRepository.AddAsistenciaAsync(asistencia);
            return Ok("Asistencia registrada con éxito.");
        }



    }
}
