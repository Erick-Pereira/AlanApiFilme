namespace AlanApiFilme.ApiModels
{
    public class Paricipante
    {
        public Guid id { get; set; }
        public string participante { get; set; }
        public DateTime data_insercao { get; set; }
        public DateTime data_inativavao { get; set; }
    }
}
