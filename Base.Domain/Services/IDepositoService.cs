using Base.Domain.DTOs.Cliente;
using Base.Domain.Entidades;
using Base.Domain.ValueObject.Basicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Services
{
    public interface IDepositoService
    {
       public Task<IEnumerable<Deposito>> GetAll();
       public Task<Deposito> GetById(int id);
    }
}
