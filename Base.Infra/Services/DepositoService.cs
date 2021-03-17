using Base.Domain.DTOs.Cliente;
using Base.Domain.Entidades;
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

        public DepositoService()
        {
        }

        //private readonly ILog _log;        
        public DepositoService(IDeposito clienteRepository)
        {
            _depRepo = clienteRepository;
            //_log = log;           
        }



        public async Task<IEnumerable<Deposito>> GetAll(int idCliente)
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

        public async Task<Deposito> GetById(int id)
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
        private IEnumerable<Deposito> ProcessarRetorno(IEnumerable<Base.Domain.Entidades.Deposito> entidades)
        {
            if (entidades.Count() <= 0)
                return null;

            return entidades;
        }

        private Deposito ProcessarRetorno(Deposito entidade)
        {
            if (entidade == null)
                return null;

            return entidade;
        }
    }
}
