
using Base.Domain.Repositorios;
using Base.Domain.Retornos;
using Base.Domain.ValueObject.Basicos;
using Base.Infra.Context;
using Base.Infra.Context.BaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Base.Infra.Repositorios
{
    public class DepositoRepository: IDeposito
    {
        public readonly BaseContext _ctx;
        //private readonly ILog _log;
        //private readonly IImagens _imgRepository;
        public DepositoRepository(BaseContext ctx)
        {
            _ctx = ctx;
            //_log = log;
            //_imgRepository = imgRepository;
        }

        public async Task<Base.Domain.Entidades.Deposito> Cadastrar(Base.Domain.Entidades.Deposito deposito)
        {
            try
            {
                _ctx.Deposito.Add(deposito);
                await _ctx.SaveChangesAsync();
                return deposito;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Cadastrar Deposito", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Deposito> Atualizar(Base.Domain.Entidades.Deposito deposito)
        {
            try
            {
                _ctx.Deposito.Update(deposito);
                await _ctx.SaveChangesAsync();
                return deposito;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao Atualizar Deposito", ex);
            }
        }

        public async Task<IEnumerable<Base.Domain.Entidades.Deposito>> GetAll()
        {
            try
            {
                return await _ctx.Deposito.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
               // _log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao listar Deposito", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Deposito> GetById(int id)
        {
            try
            {
                return await _ctx.Deposito.AsNoTracking().Include(x => x.Id).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao listar Deposito", ex);
            }
        }

     

        public async Task<Retorno> Excluir(int id)
        {
            try
            {
                var reg = await _ctx.Deposito.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (reg == null)
                    return new Retorno(false, "Registro não encontrado", "Registro não encontrado");

                _ctx.Deposito.Remove(reg);
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
