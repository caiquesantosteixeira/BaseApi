using Base.Domain.Entidades.Cliente;
using Base.Domain.ValueObject.Basicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Services.Cliente
{
    public interface ICategoriasClienteService
    {
        Task<IEnumerable<CategoriasCliente>> GetAll();
        List<RetornoPaginacao<CategoriasCliente>> DadosPaginados(int QtdPorPagina, int PagAtual, string Filtro = null, string ValueFiltro = null);
        Task<CategoriasCliente> GetById(int idcategoria);
        Task<CategoriasCliente> GetByName(string nome);
    }
}
