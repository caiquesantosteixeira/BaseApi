using Base.Domain.DTOs.Produto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Services.Produto
{
    public interface IProdutosService
    {
        Task<IEnumerable<ProdutosDTO>> GetAllByCliente(int idCliente);
        Task<IEnumerable<ProdutosDTO>> GetAllByClienteOfertas(int idCliente, int quantidade);
        Task<IEnumerable<ProdutosDTO>> GetAllByClienteCatalogo(int idCliente, bool random, int idCategoria = 0, int idUltimoProd = 0, int quantidade = 0, string pesquisa = "");
        Task<IEnumerable<ProdutosDTO>> GetAllProdutosByCategoria(int idCategoria);
        Task<ProdutosDTO> GetProdutoById(int id, int idCliente);
        Task<ProdutosDTO> GetProdutoByIdExterno(string idExterno, int idCliente);        
    }
}
