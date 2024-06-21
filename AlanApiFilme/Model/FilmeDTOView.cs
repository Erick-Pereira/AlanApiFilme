namespace AlanApiFilme.Model
{
    public class FilmeDTOView : FilmeDto
    {
        public string ValorExtenso { get; set; }

        public FilmeDTOView(FilmeDto filmeDto)
        {
            SoapClient client = new SoapClient();
            if (filmeDto != null)
            {
                this.ID = filmeDto.ID;
                this.Nome = filmeDto.Nome;
                this.Categoria = filmeDto.Categoria;
                this.Classificacao = filmeDto.Classificacao;
                this.Genero = filmeDto.Genero;
                this.Midia = filmeDto.Midia;
                this.Valor = filmeDto.Valor;
                this.Participantes = filmeDto.Participantes;
                this.TipoMidia = filmeDto.TipoMidia;
            }
        }
    }
}