namespace AlanApiFilme.ApiModels
{
    public class Genero
    {
        public Guid id { get; set; }
        public string genero { get; set; }
        public DateTime data_insercao { get; set; }
        public DateTime data_inativavao { get; set; }
    }
}