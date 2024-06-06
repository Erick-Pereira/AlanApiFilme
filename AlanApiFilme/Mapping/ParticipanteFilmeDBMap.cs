using AlanApiFilme.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlanApiFilme.Mapping
{
    public class ParticipanteFilmeDBMap : IEntityTypeConfiguration<ParticipanteFilme>
    {
        public void Configure(EntityTypeBuilder<ParticipanteFilme> builder)
        {
            builder.Property(p => p.FilmeID).IsUnicode(false).IsRequired();
            builder.Property(p => p.ParticipanteID).IsUnicode(false).IsRequired();
            builder.ToTable("PARTICIPANTE_FILME");
        }
    }
}