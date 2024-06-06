namespace AlanApiFilme.Model
{
    public class ParticipanteFilme
    {
        public Guid FilmeID { get; set; }
        public Filme Filme { get; set; }
        public Guid ParticipanteID { get; set; }
        public Participante Participante { get; set; }
    }
}