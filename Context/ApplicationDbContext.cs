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
            modelBuilder.Entity<Taller>()
                .HasMany(t => t.Participantes)
                .WithMany(p => p.Talleres)
                .UsingEntity<Dictionary<string, object>>(
                    "ParticipanteTaller",
                    j => j.HasOne<Participante>().WithMany().HasForeignKey("ParticipanteId"),
                    j => j.HasOne<Taller>().WithMany().HasForeignKey("TallerId"),
                    j => j.HasKey("ParticipanteId", "TallerId")
                );

            modelBuilder.Entity<Taller>()
                .HasMany(t => t.Asistencias)
                .WithOne(a => a.Taller)
                .HasForeignKey(a => a.TallerId);

            modelBuilder.Entity<Participante>()
                .HasMany(p => p.Asistencias)
                .WithOne(a => a.Participante)
                .HasForeignKey(a => a.ParticipanteId);
        }
    }
}
