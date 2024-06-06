using AlanApiFilme.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlanApiFilme.Mapping
{
    public class FilmeDbMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.Property(f => f.Nome).IsUnicode(false).IsRequired();
            builder.Property(f => f.CategoriaID).IsUnicode(false).IsRequired();
            builder.Property(f => f.ClassificacaoID).IsUnicode(false).IsRequired();
            builder.Property(f => f.GeneroID).IsUnicode(false).IsRequired();
            builder.Property(f => f.MidiaID).IsUnicode(false).IsRequired();
            builder.Property(f => f.TipoMidiaID).IsUnicode(false).IsRequired();
            builder.ToTable("FILMES");
        }
    }
}