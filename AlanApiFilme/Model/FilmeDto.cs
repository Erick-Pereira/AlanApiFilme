namespace AlanApiFilme.Model
{
    public class FilmeDto
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Classificacao { get; set; }
        public string Genero { get; set; }
        public string Midia { get; set; }
        public List<string> Participantes { get; set; }
        public string TipoMidia { get; set; }
    }
}