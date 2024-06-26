﻿namespace AlanApiFilme.Model
{
    public class Filme
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public Guid CategoriaID { get; set; }
        public Guid ClassificacaoID { get; set; }
        public int Valor { get; set; }
        public Guid GeneroID { get; set; }
        public Guid MidiaID { get; set; }
        public ICollection<Participante> Participantes { get; set; }
        public Guid TipoMidiaID { get; set; }
    }
}