namespace AlanApiFilme.Model
{
    public class Filme
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public Guid CategoriaID { get; set; }
        public Guid ClassificacaoID { get; set; }
        public Guid GeneroID { get; set; }
        public Guid MidiaID { get; set; }
        public ICollection<ParticipanteFilme> Participantes { get; set; }
        public Guid TipoMidiaID { get; set; }
    }
}