using Base.Domain.DTOs.Cliente;
using Base.Domain.Entidades;
using Base.Domain.ValueObject.Basicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.Domain.Services
{
    public interface ITransferenciaService
    {
       public Task<IEnumerable<Transferencia>> GetAll(int idCLiente);

        public Task<IEnumerable<Transferencia>> GetAllRecebidas(int idCLiente);
        public Task<Transferencia> GetById(int id);
    }
}
