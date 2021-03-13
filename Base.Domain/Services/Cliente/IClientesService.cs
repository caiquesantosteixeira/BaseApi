using Base.Domain.DTOs.Cliente;
using Base.Domain.ValueObject.Basicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Services.Cliente
{
    public interface IClientesService
    {
       public Task<IEnumerable<ClientesDTO>> GetAll();
       public IEnumerable<RetornoPaginacao<ClientesDTO>> DadosPaginados(int QtdPorPagina, int PagAtual, string Filtro = null, string ValueFiltro = null);
       public Task<IEnumerable<ClientesDTO>> GetByCategoria(bool random, int idcategoria, int idultimocliente, int quantidade, string pesquisa);
       public Task<ClientesDTO> GetById(int id);
       public Task<ClientesDTO> GetByTenant(string tenant, bool checaAtivo);
       public Task<ClientesDTO> GetCpfCnpj(string cpfCnpj);
    }
}
