namespace Entities
{
    public class Filme
    {
        public Guid Id { get; set; }
        private string Nome { get; set; }
        public int CategoriaId { get; set; }
        public int ClassificacaoId { get; set; }
        public int GeneroId { get; set; }
        public int TipoMidiaId { get; set; }
    }
}