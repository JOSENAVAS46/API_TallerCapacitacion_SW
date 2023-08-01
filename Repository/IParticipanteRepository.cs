using API_TallerCapacitacion_SW.Context;
using API_TallerCapacitacion_SW.Models;

namespace API_TallerCapacitacion_SW.Repository
{
    public interface IParticipanteRepository
    {
        Task<List<Participante>> GetParticipantesAsync();
        Task<Participante> GetParticipanteByIdAsync(int id);
        Task AddParticipanteAsync(Participante participante);
        Task<bool> SaveChangesAsync();

    }

    public class ParticipanteRepository : IParticipanteRepository
    {
        private readonly ApplicationDbContext _context;

        public ParticipanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Participante>> GetParticipantesAsync()
        {
            List<Participante> lstParticipantes = _context.Participantes.ToList();
            return lstParticipantes;
        }

        public async Task<Participante> GetParticipanteByIdAsync(int id)
        {
            Participante participante = await _context.Participantes.FindAsync(id);
            return participante;
        }

        public async Task AddParticipanteAsync(Participante participante)
        {
            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
