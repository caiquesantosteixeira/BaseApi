
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
    public class TransferenciaRepository: ITransferencia
    {
        public readonly BaseContext _ctx;
        //private readonly ILog _log;
        //private readonly IImagens _imgRepository;
        public TransferenciaRepository(BaseContext ctx)
        {
            _ctx = ctx;
            //_log = log;
            //_imgRepository = imgRepository;
        }

        public async Task<Base.Domain.Entidades.Transferencia> Cadastrar(Base.Domain.Entidades.Transferencia transferencia)
        {
            try
            {
                var clienteRemetente = _ctx.Cliente.FirstOrDefault(a => a.Id == transferencia.IdClienteRemetente);
                clienteRemetente.Saldo -= transferencia.Valor;


                _ctx.Cliente.Update(clienteRemetente);
                await _ctx.SaveChangesAsync();

                var clienteDestinatário = _ctx.Cliente.FirstOrDefault(a => a.Id == transferencia.IdClienteRemetente);
                clienteDestinatário.Saldo += transferencia.Valor;

                _ctx.Cliente.Update(clienteDestinatário);
                await _ctx.SaveChangesAsync();


                _ctx.Transferencia.Add(transferencia);
                await _ctx.SaveChangesAsync();
                return transferencia;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao Cadastrar transferencia", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Transferencia> Atualizar(Base.Domain.Entidades.Transferencia transferencia)
        {
            try
            {
                _ctx.Transferencia.Update(transferencia);
                await _ctx.SaveChangesAsync();
                return transferencia;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao Atualizar transferencia", ex);
            }
        }

        public async Task<IEnumerable<Base.Domain.Entidades.Transferencia>> GetAll()
        {
            try
            {
                return await _ctx.Transferencia.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
               // _log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao transferencia status", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Transferencia> GetById(int id)
        {
            try
            {
                return await _ctx.Transferencia.AsNoTracking().Include(x => x.Id).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao listar transferencia", ex);
            }
        }

       

        public async Task<Retorno> Excluir(int id)
        {
            try
            {
                var reg = await _ctx.Transferencia.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (reg == null)
                    return new Retorno(false, "Registro não encontrado", "Registro não encontrado");

                _ctx.Transferencia.Remove(reg);
                await _ctx.SaveChangesAsync();

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
