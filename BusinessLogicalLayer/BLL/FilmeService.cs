using BusinessLogicalLayer.Interfaces;
using Entities;
using Shared;

namespace BusinessLogicalLayer.BLL
{
    public class FilmeService : IFilmeService
    {
        public Task<Response> Delete(Filme filme)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<Filme>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<Filme>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Insert(Filme filme)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(Filme filme)
        {
            throw new NotImplementedException();
        }
    }
}