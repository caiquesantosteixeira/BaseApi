using Base.Domain.DTOs.Produto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Services.Produto
{
    public interface ICategoriasProdutoService
    {
        Task<IEnumerable<CategoriasProdutoDTO>> GetAll();
        Task<IEnumerable<CategoriasProdutoDTO>> GetAllCategoriaCliente(int idCliente);
        Task<IEnumerable<CategoriasProdutoDTO>> GetAllCategoriaAtivaCliente(int idCliente);
        Task<CategoriasProdutoDTO> GetCategoriaById(int id, int idCliente);
        Task<CategoriasProdutoDTO> GetCategoriaByName(string nome, int idCliente);
        Task<CategoriasProdutoDTO> GetCategoriaByIdExterno(string idExterno, int idCliente);
    }
}
