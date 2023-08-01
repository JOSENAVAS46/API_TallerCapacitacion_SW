using API_TallerCapacitacion_SW.Context;
using API_TallerCapacitacion_SW.Models;

namespace API_TallerCapacitacion_SW.Repository
{
    public interface ITallerRepository
    {
        Task<List<Taller>> GetTalleresAsync();
        Task<Taller> GetTallerByIdAsync(int id);
        Task AddTallerAsync(Taller taller);
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
            List<Taller> lstTalleres = _context.Talleres.ToList();
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

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
