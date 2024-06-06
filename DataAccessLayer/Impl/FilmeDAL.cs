using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace DataAccessLayer.Impl
{
    public class FilmeDAL : IFilmeDAL
    {
        private readonly DataBaseDbContext _db;

        public FilmeDAL(DataBaseDbContext db)
        {
            _db = db;
        }

        // Construtor do BairroService



        public async Task<Response> Delete(Filme filme)
        {
            _db.Filme.Remove(filme);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }

        public async Task<Response> Delete(Guid id)
        {
            _db.Filme.Remove(GetByID(id).Result.Item);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }

        public async Task<DataResponse<Filme>> GetAll()
        {
            try
            {
                return ResponseFactory<Filme>.CreateSuccessDataResponse(await _db.Filme.AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                return ResponseFactory<Filme>.CreateFailureDataResponse(ex);
            }
        }

        public async Task<SingleResponse<Filme>> GetByID(Guid id)
        {
            try
            {
                return ResponseFactory<Filme>.CreateSuccessItemResponse(await _db.Filme.AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(id)));
            }
            catch (Exception ex)
            {
                return ResponseFactory<Filme>.CreateFailureItemResponse(ex);
            }
        }

        public async Task<Response> Insert(Filme filme)
        {
            _db.Filme.Add(filme);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }

        public async Task<Response> Update(Filme filme)
        {
            _db.Filme.Update(filme);
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory<Response>.CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory<Response>.CreateFailureResponse(ex);
            }
        }
    }
}