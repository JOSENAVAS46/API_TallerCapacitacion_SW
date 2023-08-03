using API_TallerCapacitacion_SW.Context;
using API_TallerCapacitacion_SW.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TallerCapacitacion_SW.Repository
{
    public interface ITallerRepository
    {
        Task<List<Taller>> GetTalleresAsync();
        Task<Taller> GetTallerByIdAsync(int id);
        Task AddTallerAsync(Taller taller);
        Task UpdateTallerAsync(Taller taller);
        Task<bool> SaveChangesAsync();


    }

    public class TallerRepository : ITallerRepository
    {
        private readonly ApplicationDbContext _context;

        public TallerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Taller>> GetTalleresAsync()
        {
            List<Taller> lstTalleres = await _context.Talleres
                .Include(t => t.Participantes) // Incluir la lista de participantes del taller
                .ToListAsync();
            return lstTalleres;
        }

        public async Task<Taller> GetTallerByIdAsync(int id)
        {
            Taller taller = await _context.Talleres.FindAsync(id);
            return taller;
        }

        public async Task AddTallerAsync(Taller taller)
        {
            _context.Talleres.Add(taller);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTallerAsync(Taller taller)
        {
            _context.Talleres.Update(taller);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
