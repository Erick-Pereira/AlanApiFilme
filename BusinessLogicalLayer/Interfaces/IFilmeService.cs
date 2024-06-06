using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IFilmeService
    {
        Task<Response> Delete(Filme filme);

        Task<DataResponse<Filme>> GetAll();

        Task<SingleResponse<Filme>> GetByID(int id);

        Task<Response> Insert(Filme filme);

        Task<Response> Update(Filme filme);
    }
}