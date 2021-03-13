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
        Task<IEnumerable<Transferencia>> GetByCategoria(int id);
        Task<IEnumerable<Transferencia>> GetAllByClienteCatalogo(bool random, int idCategoria = 0, int idUltimoCliente = 0, int quantidade = 0, string pesquisa = "");
        Task<Transferencia> GetCpfCnpj(string cpfCnpj);     
        Task<Transferencia> Cadastrar(Transferencia cliente);
        Task<Transferencia> Atualizar(Transferencia cliente);
        Task<Retorno> Excluir(int id);
    }
}
