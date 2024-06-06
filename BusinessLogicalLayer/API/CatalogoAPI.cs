using BusinessLogicalLayer.Interfaces;
using Entities;
using Shared;
using Shared.Constants;
using System.Text.Json;

namespace BusinessLogicalLayer.API
{
    public class CatalogoAPI : ICatalogoAPI
    {


        public async Task<DataResponse<Categoria>> BuscaCategorias()
        {

            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(StringConsts.link + "/Categoria");
                string a = await response.Content.ReadAsStringAsync();
                var alice2 = JsonSerializer.Deserialize<List<Categoria>>(a);
                List<Categoria> categorias = new List<Categoria>();
                return ResponseFactory<Categoria>.CreateSuccessDataResponse(categorias);

            }
            catch (Exception ex)
            {
                return ResponseFactory<Categoria>.CreateFailureDataResponse(ex);
            }
        }
    }
}