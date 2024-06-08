using AlanApiFilme.Model;
using AlanApiFilme.Profiles;
using Microsoft.AspNetCore.Mvc;

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
            if (string.IsNullOrWhiteSpace(filme.ID))
            {
                Filme filme1 = await filme.ToEntity();
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
            var result = await _db.Filme.FindAsync(Guid.Parse(id)).Result.ToDto();
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));
        }
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var result = _db.Filme.ToList();
            List<FilmeDto> list = new List<FilmeDto>();
            for (int i = 0; i < result.Count; i++)
            {
                FilmeDto filme = await result[i].ToDto();
                list.Add(filme);
            }
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(list));
        }
    }
}