namespace AlanApiFilme.Model
{
    public class Participante
    {
        public Guid id { get; set; }
        public ICollection<ParticipanteFilme> Filmes { get; set; }
    }
}
