namespace AlanApiFilme.ApiModels
{
    public class Categoria
    {
        public Guid id { get; set; }
        public string categoria { get; set; }
        public DateTime data_insercao { get; set; }
        public DateTime data_inativavao { get; set; }

    }
}
