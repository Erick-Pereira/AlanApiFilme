using AlanApiFilme.Model;
using Newtonsoft.Json;

namespace AlanApiFilme.Profiles
{
    public static class FilmeExtensions
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<string> GetCategoriaNomeById(Guid id)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/classificacao/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var categoria = JsonConvert.DeserializeObject<string>(responseBody);
            return categoria;
        }

        public static async Task<string> GetClassificacaoNomeById(Guid id)
        {
            var response = await httpClient.GetAsync($"https://api.example.com/classificacoes/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var classificacao = JsonConvert.DeserializeObject<string>(responseBody);
            return classificacao;
        }

        public static async Task<string> GetGeneroNomeById(Guid id)
        {
            var response = await httpClient.GetAsync($"https://api.example.com/generos/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var genero = JsonConvert.DeserializeObject<string>(responseBody);
            return genero;
        }

        public static async Task<string> GetMidiaNomeById(Guid id)
        {
            var response = await httpClient.GetAsync($"https://api.example.com/midias/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var midia = JsonConvert.DeserializeObject<string>(responseBody);
            return midia;
        }

        public static async Task<string> GetTipoMidiaNomeById(Guid id)
        {
            var response = await httpClient.GetAsync($"https://api.example.com/tipomidias/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var tipoMidia = JsonConvert.DeserializeObject<string>(responseBody);
            return tipoMidia;
        }

        public static async Task<Guid> GetCategoriaIdByNome(string nome)
        {
            var response = await httpClient.GetAsync($"https://api.example.com/categorias?nome={nome}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var categoria = JsonConvert.DeserializeObject<Guid>(responseBody);
            return categoria;
        }

        public static async Task<Guid> GetClassificacaoIdByNome(string nome)
        {
            var response = await httpClient.GetAsync($"https://api.example.com/classificacoes?nome={nome}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var classificacao = JsonConvert.DeserializeObject<Guid>(responseBody);
            return classificacao;
        }

        public static async Task<Guid> GetGeneroIdByNome(string nome)
        {
            var response = await httpClient.GetAsync($"https://api.example.com/generos?nome={nome}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var genero = JsonConvert.DeserializeObject<Guid>(responseBody);
            return genero;
        }

        public static async Task<Guid> GetMidiaIdByNome(string nome)
        {
            var response = await httpClient.GetAsync($"https://api.example.com/midias?nome={nome}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var midia = JsonConvert.DeserializeObject<Guid>(responseBody);
            return midia;
        }

        public static async Task<Guid> GetTipoMidiaIdByNome(string nome)
        {
            var response = await httpClient.GetAsync($"https://api.example.com/tipomidias?nome={nome}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var tipoMidia = JsonConvert.DeserializeObject<Guid>(responseBody);
            return tipoMidia;
        }
        public static async Task<FilmeDto> ToDto(this Filme filme)
        {

            return new FilmeDto
            {
                ID = filme.ID,
                Nome = filme.Nome,
                // Mapeamento dos IDs para strings, aqui você precisará consultar os nomes reais usando os IDs
                Categoria = await GetCategoriaNomeById(filme.CategoriaID),
                Classificacao = await GetClassificacaoNomeById(filme.ClassificacaoID),
                Genero = await GetGeneroNomeById(filme.GeneroID),
                Midia = await GetMidiaNomeById(filme.MidiaID),
                TipoMidia = await GetTipoMidiaNomeById(filme.TipoMidiaID),
                //Participantes = new List<string>() // Adicione a lógica para popular a lista de participantes
            };
        }

        public static async Task<Filme> ToEntity(this FilmeDto filmeDto)
        {
            return new Filme
            {
                ID = filmeDto.ID,
                Nome = filmeDto.Nome,
                // Mapeamento das strings para IDs, aqui você precisará consultar os IDs reais usando os nomes
                CategoriaID = await GetCategoriaIdByNome(filmeDto.Categoria),
                ClassificacaoID = await GetClassificacaoIdByNome(filmeDto.Classificacao),
                GeneroID = await GetGeneroIdByNome(filmeDto.Genero),
                MidiaID = await GetMidiaIdByNome(filmeDto.Midia),
                TipoMidiaID = await GetTipoMidiaIdByNome(filmeDto.TipoMidia),
                // Note que a propriedade Participantes não existe na classe Filme, então não há mapeamento inverso
            };
        }


    }
}