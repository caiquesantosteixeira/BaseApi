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

        Task<Saque> GetById(int id);
        Task<Saque> Cadastrar(Saque saque);
        Task<Saque> Atualizar(Saque saque);
        Task<Retorno> Excluir(int id);
    }
}
