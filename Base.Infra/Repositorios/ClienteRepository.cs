
using Base.Domain.Repositorios;
using Base.Domain.Retornos;
using Base.Domain.Shared.Entidades.Usuarios;
using Base.Domain.ValueObject.Basicos;
using Base.Infra.Context;
using Base.Infra.Context.BaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
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
                IUserStore<Usuario> _store = new UserStore<Usuario>(new BaseContext());
                UserManager<Usuario> _userManager = new UserManager<Usuario>(_store, null, new PasswordHasher<Usuario>(), null, null, null, null, null, null);


                var user = new Usuario
                {
                    UserName = cliente.Cpf,
                    Email = "",
                    EmailConfirmed = true,
                    NormalizedEmail = "",
                    SecurityStamp = "5X5F7RIXE5DHAIWEM4MCGM7QRFQOK67C",
                    ConcurrencyStamp = "6625979f-d1c1-46fb-aa54-4e094badd8bd"
                };

                var result = await _userManager.CreateAsync(user, cliente.Senha);

                cliente.IdUsuario = user.Id;
                _ctx.Cliente.Add(cliente);
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
                _ctx.Cliente.Update(cliente);
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
                return await _ctx.Cliente.ToListAsync();
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
                return await _ctx.Cliente.AsNoTracking().Include(x => x.Id).FirstOrDefaultAsync(x => x.Id == id);
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
                return await _ctx.Cliente.AsNoTracking().FirstOrDefaultAsync(x => x.Cpf == cpfCnpj);
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
                var reg = await _ctx.Cliente.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                if (reg == null)
                    return new Retorno(false, "Registro não encontrado", "Registro não encontrado");


                //string _nomeimagem = reg.Imagem;
                //string _cnpj = reg.CpfCnpj;

                _ctx.Cliente.Remove(reg);
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
