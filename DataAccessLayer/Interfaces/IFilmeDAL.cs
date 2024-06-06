using Entities;
using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IFilmeDAL
    {
        Task<Response> Delete(Filme filme);

        Task<DataResponse<Filme>> GetAll();

        Task<SingleResponse<Filme>> GetByID(Guid id);

        Task<Response> Insert(Filme filme);

        Task<Response> Update(Filme filme);
    }
}
