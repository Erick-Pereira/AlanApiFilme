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
            if (filme.ID.Equals(null) || filme.ID.Equals(0))
            {
                _db.Filme.Add(await filme.ToEntity());
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
            var result = await _db.Filme.FindAsync(Guid.Parse(id));
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
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));
        }
    }
}