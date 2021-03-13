using Base.Domain.DTOs.Cliente;
using Base.Domain.Entidades;
using Base.Domain.ValueObject.Basicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Services
{
    public interface IClientesService
    {
       public Task<IEnumerable<Cliente>> GetAll();
       public Task<Cliente> GetById(int id);
       public Task<Cliente> GetCpfCnpj(string cpfCnpj);
    }
}
