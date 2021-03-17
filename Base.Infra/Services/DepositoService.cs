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
    public sealed class DepositoService : IDepositoService
    {
        private readonly IDeposito _depRepo;
        //private readonly ILog _log;        
        public DepositoService(IDeposito clienteRepository)
        {
            _depRepo = clienteRepository;
            //_log = log;           
        }



        public async Task<IEnumerable<Base.Domain.Entidades.Deposito>> GetAll(int idCliente)
        {
            try
            {
                var entidades = await _depRepo.GetAll(idCliente);
                return entidades;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro DepositoService", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Deposito> GetById(int id)
        {
            try
            {
                var entidade = await _depRepo.GetById(id);
                return entidade;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro DepositoService", ex);
            }
        }




        // Métodos públicos de processamento do retorno desse servico
        private IEnumerable<Base.Domain.Entidades.Deposito> ProcessarRetorno(IEnumerable<Base.Domain.Entidades.Deposito> entidades)
        {
            if (entidades.Count() <= 0)
                return null;

            return entidades;
        }

        private Base.Domain.Entidades.Deposito ProcessarRetorno(Base.Domain.Entidades.Deposito entidade)
        {
            if (entidade == null)
                return null;

            return entidade;
        }
    }
}
