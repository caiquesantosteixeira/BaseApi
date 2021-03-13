using Base.Domain.Entidades;
using Base.Domain.Retornos;
using Base.Domain.ValueObject.Basicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Repositorios
{
    public interface ICliente
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<IEnumerable<Cliente>> GetByCategoria(int id);
        Task<IEnumerable<Cliente>> GetAllByClienteCatalogo(bool random, int idCategoria = 0, int idUltimoCliente = 0, int quantidade = 0, string pesquisa = "");
        Task<Cliente> GetCpfCnpj(string cpfCnpj);     
        Task<Cliente> Cadastrar(Cliente cliente);
        Task<Cliente> Atualizar(Cliente cliente);
        Task<Retorno> Excluir(int id);
    }
}
