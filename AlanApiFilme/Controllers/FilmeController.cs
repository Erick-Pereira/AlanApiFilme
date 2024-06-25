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

        [HttpPut]
        public async Task<JsonResult> Update(FilmeDto filmeDto)
        {
            try
            {
                // Remove "string" from the ID if present
                filmeDto.ID = filmeDto.ID.Replace("string", "");
                Filme filme = await filmeDto.ToEntity();

                if (!string.IsNullOrWhiteSpace(filmeDto.ID))
                {
                    // Fetch the existing entity from the database
                    var existingFilme = await _db.Filme
                        .Include(f => f.Participantes)
                        .FirstOrDefaultAsync(f => f.ID == Guid.Parse(filmeDto.ID));

                    if (existingFilme != null)
                    {
                        // Limpa os participantes existentes
                        existingFilme.Participantes.Clear();

                        // Adiciona os novos participantes ou reutiliza os existentes do contexto
                        foreach (var participanteDto in filme.Participantes)
                        {
                            var participante = await _db.Participante.FindAsync(participanteDto.id);
                            if (participante != null)
                            {
                                existingFilme.Participantes.Add(participante);
                            }
                            else
                            {
                                existingFilme.Participantes.Add(participanteDto);
                            }
                        }

                        // Mapeia o DTO para a entidade existente
                        existingFilme.Nome = filme.Nome;
                        existingFilme.CategoriaID = filme.CategoriaID;
                        existingFilme.ClassificacaoID = filme.ClassificacaoID;
                        existingFilme.GeneroID = filme.GeneroID;
                        existingFilme.MidiaID = filme.MidiaID;
                        existingFilme.Valor = filme.Valor;
                        existingFilme.TipoMidiaID = filme.TipoMidiaID;

                        // Update the entity
                        _db.Filme.Update(existingFilme);
                    }
                    else
                    {
                        // Handle case where entity is not found
                        return new JsonResult(NotFound());
                    }
                }
                else
                {
                    return new JsonResult(BadRequest("Invalid ID"));
                }

                // Save changes to the database
                await _db.SaveChangesAsync();

                return new JsonResult(Ok(filmeDto));
            }
            catch (DbUpdateException ex)
            {
                // Log the exception details for further analysis
                var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new JsonResult(new { error = "An error occurred while updating the record.", details = innerExceptionMessage })
                {
                    StatusCode = 500
                };
            }
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
            FilmeDto result = await _db.Filme.Include(f => f.Participantes).FirstOrDefaultAsync(f => f.ID == Guid.Parse(id)).Result.ToDto();
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
            var result = await _db.Filme.Include(f => f.Participantes).ToListAsync();
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
        [HttpDelete]
        public async Task<JsonResult> Delete(string id)
        {
            Guid ID = Guid.Parse(id);
            Filme result = await _db.Filme.FindAsync(ID);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            _db.Filme.Remove(result);
            _db.SaveChanges();
            return new JsonResult(Ok());
        }
    }
}