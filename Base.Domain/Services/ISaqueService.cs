using Base.Domain.DTOs.Cliente;
using Base.Domain.Entidades;
using Base.Domain.ValueObject.Basicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Services
{
    public interface ISaquesService
    {
       public Task<IEnumerable<Saque>> GetAll(int idCliente);
       public Task<Saque> GetById(int id);
    }
}
