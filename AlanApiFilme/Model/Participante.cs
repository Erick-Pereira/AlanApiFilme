namespace AlanApiFilme.Model
{
    public class Participante
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ICollection<ParticipanteFilme> Filmes { get; set; }
    }
}
