using Base.Domain.DTOs.Cliente;
using Base.Domain.Repositorios;
//using Base.Domain.Repositorios.Logging;
using Base.Domain.Services;
using Base.Domain.ValueObject.Basicos;
//using Base.Infra.Helpers.Diretorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Infra.Services.Cliente
{
    public sealed class  TransfereneciaService : ITransferenciaService
    {
        private readonly ITransferencia _traRepo;
        //private readonly ILog _log;        
        public TransfereneciaService(ITransferencia transferenciaRepository)
        {
            _traRepo = transferenciaRepository;
            //_log = log;           
        }



        public async Task<IEnumerable<Base.Domain.Entidades.Transferencia>> GetAll(int idCliente)
        {
            try
            {
                var entidades = await _traRepo.GetAll(idCliente);
                return entidades;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro transferenciaService", ex);
            }
        }

        public async Task<IEnumerable<Base.Domain.Entidades.Transferencia>> GetAllRecebidas(int idCliente)
        {
            try
            {
                var entidades = await _traRepo.GetAllRecebidas(idCliente);
                return entidades;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro transferenciaService", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Transferencia> GetById(int id)
        {
            try
            {
                var entidade = await _traRepo.GetById(id);
                return entidade;
            }
            catch(Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro transferenciaService", ex);
            }
        }

        // Métodos públicos de processamento do retorno desse servico
        private IEnumerable<Base.Domain.Entidades.Transferencia> ProcessarRetorno(IEnumerable<Base.Domain.Entidades.Transferencia> entidades)
        {
            if (entidades.Count() <= 0)
                return null;

            return entidades;
        }

        private Base.Domain.Entidades.Transferencia ProcessarRetorno(Base.Domain.Entidades.Transferencia entidade)
        {            
            if (entidade == null)
                return null;

            return entidade;
        }
    }
}
