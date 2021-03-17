
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
    public class SaqueRepository: ISaque
    {
        public readonly BaseContext _ctx;
        //private readonly ILog _log;
        //private readonly IImagens _imgRepository;
        public SaqueRepository(BaseContext ctx)
        {
            _ctx = ctx;
            //_log = log;
            //_imgRepository = imgRepository;
        }


        public async Task<Base.Domain.Entidades.Saque> Cadastrar(Base.Domain.Entidades.Saque saque)
        {
            try
            {
                _ctx.Saque.Add(saque);
                await _ctx.SaveChangesAsync();
                return saque;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao Cadastrar saque", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Saque> Atualizar(Base.Domain.Entidades.Saque saque)
        {
            try
            {
                _ctx.Saque.Update(saque);
                await _ctx.SaveChangesAsync();
                return saque;
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao Atualizar saque", ex);
            }
        }


        public async Task<IEnumerable<Base.Domain.Entidades.Saque>> GetAll(int idCLiente)
        {
            try
            {
                return await _ctx.Saque.Where(a => a.IdCliente == idCLiente).ToListAsync();
            }
            catch (Exception ex)
            {
                // _log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao listar saque", ex);
            }
        }

        public async Task<Base.Domain.Entidades.Saque> GetById(int id)
        {
            try
            {
                return await _ctx.Saque.AsNoTracking().Include(x => x.Id).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                //_log.GerarLogDisc("Erro", ex: ex);
                throw new Exception("Erro ao listar saque", ex);
            }
        }

        public async Task<Retorno> Excluir(int id)
        {
            try
            {
                var reg = await _ctx.Saque.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (reg == null)
                    return new Retorno(false, "Registro não encontrado", "Registro não encontrado");


                //string _nomeimagem = reg.Imagem;
                //string _cnpj = reg.CpfCnpj;

                _ctx.Saque.Remove(reg);
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
