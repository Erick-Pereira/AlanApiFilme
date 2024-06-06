using AlanApiFilme.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AlanApiFilme
{
    public class DataBaseDbContext : DbContext
    {
        public DbSet<Filme> Filme { get; set; }
        public DbSet<ParticipanteFilme> ParticipanteFilmes { get; set; }
        public DbSet<Participante> Participante { get; set; }
        public DataBaseDbContext(DbContextOptions<DataBaseDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipanteFilme>().HasKey(ef => new { ef.ParticipanteID, ef.FilmeID });
            modelBuilder.Entity<ParticipanteFilme>().HasOne(E => E.Filme).WithMany(E => E.Participantes).HasForeignKey(E => E.FilmeID);
            modelBuilder.Entity<ParticipanteFilme>().HasOne(F => F.Participante).WithMany(F => F.Filmes).HasForeignKey(F => F.ParticipanteID);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}