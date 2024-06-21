using AlanApiFilme.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AlanApiFilme
{
    public class DataBaseDbContext : DbContext
    {
        public DbSet<Filme> Filme { get; set; } = null!;
        public DbSet<Participante> Participante { get; set; } = null!;

        public DataBaseDbContext(DbContextOptions<DataBaseDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participante>()
        .HasMany(e => e.Filmes)
        .WithMany(e => e.Participantes);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}