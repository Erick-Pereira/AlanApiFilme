using AlanApiFilme.Model;
using AlanApiFilme.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlanApiFilme.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly DataBaseDbContext _db;

        public FilmeController(DataBaseDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<JsonResult> Create(FilmeDto filme)
        {
            filme.ID = filme.ID.Replace("string", "");
            if (string.IsNullOrWhiteSpace(filme.ID))
            {

                Filme filme1 = await filme.ToEntity();
                List<Participante> participantes = filme1.Participantes.ToList();
                List<Participante> participantes1 = new List<Participante>();
                for (int i = 0; i < participantes.Count; i++)
                {
                    Participante participante = await _db.Participante.FindAsync(participantes[i].id);
                    participantes1.Add(participante);
                }
                filme1.Participantes = participantes1;
                _db.Filme.Add(filme1);
            }
            else
            {
                var filmeInDb = await _db.Filme.FindAsync(filme.ID);
                if (filmeInDb == null)
                {
                    return new JsonResult(NotFound());
                }
            }
            _db.SaveChanges();
            return new JsonResult(Ok(filme));
        }

        [HttpGet]
        public async Task<JsonResult> Get(string id)
        {
            SoapClient client = new SoapClient();
            FilmeDto result = await _db.Filme.FindAsync(Guid.Parse(id)).Result.ToDto();
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            FilmeDTOView filmeDTOView = new FilmeDTOView(result);
            filmeDTOView.ValorExtenso = await client.GetNumberInWords(filmeDTOView.Valor);
            return new JsonResult(Ok(filmeDTOView));
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var result = _db.Filme.Include(f => f.Participantes).ToList();
            List<FilmeDTOView> list = new List<FilmeDTOView>();
            for (int i = 0; i < result.Count; i++)
            {
                SoapClient client = new SoapClient();
                FilmeDto filme = await result[i].ToDto();
                FilmeDTOView filmeDTOView = new FilmeDTOView(filme);
                filmeDTOView.ValorExtenso = await client.GetNumberInWords(filmeDTOView.Valor);
                list.Add(filmeDTOView);
            }
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(list));
        }
    }
}