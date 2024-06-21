namespace AlanApiFilme.ApiModels
{
    public class TipoMidia
    {
        public Guid id { get; set; }
        public string tipo_midia { get; set; }
        public DateTime data_insercao { get; set; }
        public DateTime data_inativavao { get; set; }
    }
}