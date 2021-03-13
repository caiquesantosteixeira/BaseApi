using Base.Domain.Entidades;
using Base.Domain.Retornos;
using Base.Domain.ValueObject.Basicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Repositorios
{
    public interface ITransferencia
    {
        Task<IEnumerable<Transferencia>> GetAll();
        Task<Transferencia> GetById(int id);
        Task<Transferencia> Cadastrar(Transferencia cliente);
        Task<Transferencia> Atualizar(Transferencia cliente);
        Task<Retorno> Excluir(int id);
    }
}
