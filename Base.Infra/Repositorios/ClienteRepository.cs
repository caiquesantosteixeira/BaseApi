
using Base.Domain.Repositorios;
using Base.Domain.Retornos;
using Base.Domain.ValueObject.Basicos;
using Base.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Base.Infra.Repositorios
{
    public class ClienteRepository: ICliente
    {
        public readonly BaseContext _ctx;
        //private readonly ILog _log;
        //private readonly IImagens _imgRepository;
        public ClienteRepository(BaseContext ctx)
        {
            _ctx = ctx;
            //_log = log;
            //_imgRepository = imgRepository;
        }

        public async Task<Base.Domain.Entidades.Cliente> Cadastrar(Base.Domain.Entidades.Cliente cliente)
        {
            try
            {
                _ctx.Clientes.Add(cliente);
                await _ctx.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao Cadastrar cliente", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Cliente> Atualizar(Base.Domain.Entidades.Cliente cliente)
        {
            try
            {
                _ctx.Clientes.Update(cliente);
                await _ctx.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao Atualizar cliente", ex);
            }
        }

        public async Task<IEnumerable<Base.Domain.Entidades.Cliente>> GetAll()
        {
            try
            {
                return await _ctx.Clientes.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
               // _log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao listar status", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Cliente> GetById(int id)
        {
            try
            {
                return await _ctx.Clientes.AsNoTracking().Include(x => x.Id).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao listar cliente", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Cliente> GetCpfCnpj(string cpfCnpj)
        {
            try
            {
                //var doc = cpfCnpj.SomenteNumeros();
                return await _ctx.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Cpf == cpfCnpj);
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao listar cliente", ex);
            }
        }

        public async Task<Retorno> Excluir(int id)
        {
            try
            {
                var reg = await _ctx.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (reg == null)
                    return new Retorno(false, "Registro não encontrado", "Registro não encontrado");


                //string _nomeimagem = reg.Imagem;
                //string _cnpj = reg.CpfCnpj;

                _ctx.Clientes.Remove(reg);
                await _ctx.SaveChangesAsync();

                //_imgRepository.ExcluirImagemClientes(_cnpj,_nomeimagem);

                return new Retorno(true, "Registro excluido com successo.", "Registro excluido com successo.");
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro Excluir", ex);
            }
        }
    }
}
