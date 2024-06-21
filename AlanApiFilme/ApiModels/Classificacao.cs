namespace AlanApiFilme.ApiModels
{
    public class Classificacao
    {
        public Guid id { get; set; }
        public string classificacao { get; set; }
        public DateTime data_insercao { get; set; }
        public DateTime data_inativavao { get; set; }
    }
}