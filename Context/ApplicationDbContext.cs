using API_TallerCapacitacion_SW.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TallerCapacitacion_SW.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Taller> Talleres { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
