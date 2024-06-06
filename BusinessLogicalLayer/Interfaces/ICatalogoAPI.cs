using Entities;
using Shared;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ICatalogoAPI
    {
        Task<DataResponse<Categoria>> BuscaCategorias();
    }
}