using Base.Domain.Entidades;
using Base.Domain.Retornos;
using Base.Domain.ValueObject.Basicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Repositorios
{
    public interface ISaque
    {
        Task<IEnumerable<Saque>> GetAll();
        Task<IEnumerable<Saque>> GetByCategoria(int id);
        Task<IEnumerable<Saque>> GetAllByClienteCatalogo(bool random, int idCategoria = 0, int idUltimoCliente = 0, int quantidade = 0, string pesquisa = "");
        Task<Cliente> GetCpfCnpj(string cpfCnpj);     
        Task<Cliente> Cadastrar(Saque cliente);
        Task<Cliente> Atualizar(Saque cliente);
        Task<Retorno> Excluir(int id);
    }
}
