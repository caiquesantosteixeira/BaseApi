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
    public sealed class SaqueService : ISaquesService
    {
        private readonly ISaque _saqueRepo;
        //private readonly ILog _log;        
        public SaqueService(ISaque saqueRepository)
        {
            _saqueRepo = saqueRepository;
            //_log = log;           
        }



        public async Task<IEnumerable<Base.Domain.Entidades.Saque>> GetAll(int idCliente)
        {
            try
            {
                var entidades = await _saqueRepo.GetAll(idCliente);
                return entidades;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro SaqueService", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Saque> GetById(int id)
        {
            try
            {
                var entidade = await _saqueRepo.GetById(id);
                return entidade;
            }
            catch(Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro SaqueService", ex);
            }
        }
   

        

        // Métodos públicos de processamento do retorno desse servico
        private IEnumerable<Base.Domain.Entidades.Saque> ProcessarRetorno(IEnumerable<Base.Domain.Entidades.Saque> entidades)
        {
            if (entidades.Count() <= 0)
                return null;

            return entidades;
        }

        private Base.Domain.Entidades.Saque ProcessarRetorno(Base.Domain.Entidades.Saque entidade)
        {            
            if (entidade == null)
                return null;

            return entidade;
        }
    }
}
