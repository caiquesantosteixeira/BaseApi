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
    public sealed class  ClientesService : IClientesService
    {
        private readonly ICliente _cliRepo;
        //private readonly ILog _log;        
        public ClientesService(ICliente clienteRepository)
        {
            _cliRepo = clienteRepository;
            //_log = log;           
        }



        public async Task<IEnumerable<Base.Domain.Entidades.Cliente>> GetAll()
        {
            try
            {
                var entidades = await _cliRepo.GetAll();
                return entidades;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ClientesService", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Cliente> GetById(int id)
        {
            try
            {
                var entidade = await _cliRepo.GetById(id);
                return entidade;
            }
            catch(Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ClientesService", ex);
            }
        }
   

        public async Task<Base.Domain.Entidades.Cliente> GetCpfCnpj(string cpfCnpj)
        {
            try
            {
                var entidade = await _cliRepo.GetCpfCnpj(cpfCnpj);
                return entidade;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ClientesService", ex);
            }
        }

        // Métodos públicos de processamento do retorno desse servico
        private IEnumerable<Base.Domain.Entidades.Cliente> ProcessarRetorno(IEnumerable<Base.Domain.Entidades.Cliente> entidades)
        {
            if (entidades.Count() <= 0)
                return null;

            return entidades;
        }

        private Base.Domain.Entidades.Cliente ProcessarRetorno(Base.Domain.Entidades.Cliente entidade)
        {            
            if (entidade == null)
                return null;

            return entidade;
        }
    }
}
