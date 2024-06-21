namespace AlanApiFilme.Model
{
    public class Participante
    {
        public Guid id { get; set; }
        public ICollection<Filme> Filmes { get; set; }
    }
}