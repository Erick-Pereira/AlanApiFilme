using AlanApiFilme.ApiModels;
using AlanApiFilme.Model;
using System.Text.Json;

namespace AlanApiFilme.Profiles
{
    public static class FilmeExtensions
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<string> GetCategoriaNomeById(Guid id)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/categoria/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(responseBody);
            return categoria.categoria;
        }

        public static async Task<string> GetClassificacaoNomeById(Guid id)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/classificacao/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Classificacao classificacao = JsonSerializer.Deserialize<Classificacao>(responseBody);
            return classificacao.classificacao;
        }

        public static async Task<string> GetGeneroNomeById(Guid id)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/genero/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Genero genero = JsonSerializer.Deserialize<Genero>(responseBody);
            return genero.genero;
        }

        public static async Task<string> GetMidiaNomeById(Guid id)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/midia/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Midia midia = JsonSerializer.Deserialize<Midia>(responseBody);
            return midia.midia;
        }
        public static async Task<string> GetTipoMidiaNomeById(Guid id)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/tipomidia/{id}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            TipoMidia tipoMidia = JsonSerializer.Deserialize<TipoMidia>(responseBody);
            return tipoMidia.tipo_midia;
        }

        public static async Task<Guid> GetCategoriaIdByNome(string nome)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/categoria?nome={nome}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            List<Categoria> list = JsonSerializer.Deserialize<List<Categoria>>(responseBody);
            Categoria categoria = new Categoria();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].categoria == nome)
                {
                    categoria = list[i];
                    break;
                }
            }
            return categoria.id;
        }

        public static async Task<Guid> GetClassificacaoIdByNome(string nome)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/classificacoes?nome={nome}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            List<Classificacao> list = JsonSerializer.Deserialize<List<Classificacao>>(responseBody);
            Classificacao classificacao = new Classificacao();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].classificacao == nome)
                {
                    classificacao = list[i];
                    break;
                }
            }
            return classificacao.id;
        }

        public static async Task<Guid> GetGeneroIdByNome(string nome)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/generos?nome={nome}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            List<Genero> list = JsonSerializer.Deserialize<List<Genero>>(responseBody);
            Genero genero = new Genero();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].genero == nome)
                {
                    genero = list[i];
                    break;
                }
            }
            return genero.id;
        }

        public static async Task<Guid> GetMidiaIdByNome(string nome)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/midias?nome={nome}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            List<Midia> list = JsonSerializer.Deserialize<List<Midia>>(responseBody);
            Midia midia = new Midia();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].midia == nome)
                {
                    midia = list[i];
                    break;
                }
            }
            return midia.id;
        }

        public static async Task<Guid> GetTipoMidiaIdByNome(string nome)
        {
            var response = await httpClient.GetAsync($"http://localhost:8080/tiposmidia?nome={nome}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            List<TipoMidia> list = JsonSerializer.Deserialize<List<TipoMidia>>(responseBody);
            TipoMidia tipoMidia = new TipoMidia();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].tipo_midia == nome)
                {
                    tipoMidia = list[i];
                    break;
                }
            }
            return tipoMidia.id;
        }
        public static async Task<FilmeDto> ToDto(this Filme filme)
        {

            FilmeDto filmeDto = new FilmeDto
            {
                ID = filme.ID.ToString(),
                Nome = filme.Nome,
                // Mapeamento dos IDs para strings, aqui você precisará consultar os nomes reais usando os IDs
                Categoria = await GetCategoriaNomeById(filme.CategoriaID),
                Classificacao = await GetClassificacaoNomeById(filme.ClassificacaoID),
                Genero = await GetGeneroNomeById(filme.GeneroID),
                Midia = await GetMidiaNomeById(filme.MidiaID),
                TipoMidia = await GetTipoMidiaNomeById(filme.TipoMidiaID),
                //Participantes = new List<string>() // Adicione a lógica para popular a lista de participantes
            };
            return filmeDto;
        }

        public static async Task<Filme> ToEntity(this FilmeDto filmeDto)
        {
            Guid Id = Guid.NewGuid();
            if (!string.IsNullOrWhiteSpace(filmeDto.ID))
            {
                Id = Guid.Parse(filmeDto.ID);
            }
            Filme filme = new Filme
            {
                ID = Id,
                Nome = filmeDto.Nome,
                // Mapeamento das strings para IDs, aqui você precisará consultar os IDs reais usando os nomes
                CategoriaID = await GetCategoriaIdByNome(filmeDto.Categoria),
                ClassificacaoID = await GetClassificacaoIdByNome(filmeDto.Classificacao),
                GeneroID = await GetGeneroIdByNome(filmeDto.Genero),
                MidiaID = await GetMidiaIdByNome(filmeDto.Midia),
                TipoMidiaID = await GetTipoMidiaIdByNome(filmeDto.TipoMidia),
                // Note que a propriedade Participantes não existe na classe Filme, então não há mapeamento inverso
            };
            return filme;
        }


    }
}