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

        Task<Deposito> GetById(int id);
        Task<Deposito> Cadastrar(Deposito cliente);
        Task<Deposito> Atualizar(Deposito cliente);
        Task<Retorno> Excluir(int id);
    }
}
