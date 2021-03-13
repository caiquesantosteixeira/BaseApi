using Base.Domain.Entidades;
using Base.Domain.Retornos;
using Base.Domain.ValueObject.Basicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Repositorios
{
    public interface IDeposito
    {
        Task<IEnumerable<Deposito>> GetAll();
        Task<IEnumerable<Deposito>> GetByCategoria(int id);
        Task<IEnumerable<Deposito>> GetAllByClienteCatalogo(bool random, int idCategoria = 0, int idUltimoCliente = 0, int quantidade = 0, string pesquisa = "");
        Task<Cliente> GetCpfCnpj(string cpfCnpj);     
        Task<Cliente> Cadastrar(Deposito cliente);
        Task<Cliente> Atualizar(Deposito cliente);
        Task<Retorno> Excluir(int id);
    }
}
