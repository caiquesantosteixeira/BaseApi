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
        Task<Cliente> GetCpfCnpj(string cpfCnpj);

        Task<Cliente> GetById(int id);
        Task<Cliente> Cadastrar(Cliente cliente);
        Task<Cliente> Atualizar(Cliente cliente);
        Task<Retorno> Excluir(int id);
    }
}
