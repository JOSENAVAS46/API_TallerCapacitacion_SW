using API_TallerCapacitacion_SW.Context;
using API_TallerCapacitacion_SW.Models;

namespace API_TallerCapacitacion_SW.Repository
{
    public interface IAsistenciaRepository
    {
        Task<List<Asistencia>> GetAsistenciasAsync();
        Task<Asistencia> GetAsistenciaByIdAsync(int id);
        Task AddAsistenciaAsync(Asistencia asistencia);
        Task<bool> SaveChangesAsync();

    }

    public class AsistenciaRepository : IAsistenciaRepository
    {
        private readonly ApplicationDbContext _context;

        public AsistenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Asistencia>> GetAsistenciasAsync()
        {
            List<Asistencia> lstAsistencias = _context.Asistencias.ToList();
            return lstAsistencias;
        }

        public async Task<Asistencia> GetAsistenciaByIdAsync(int id)
        {
            Asistencia asistencia = await _context.Asistencias.FindAsync(id);
            return asistencia;
        }

        public async Task AddAsistenciaAsync(Asistencia asistencia)
        {
            _context.Asistencias.Add(asistencia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }   
    }
}
