using Base.Domain.Handler;
using Base.Domain.Handler.Usuario;
using Base.Domain.Repositorios;
using Base.Domain.Repositorios.Usuarios;
using Base.Domain.Services;
using Base.Infra.Repositorios;
using Base.Infra.Repositorios.Usuarios;
using Base.Infra.Services;
using Base.Infra.Services.Cliente;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Base.API.Configuracoes
{
    public static class DependenciasClassesConfig
    {
        public static IServiceCollection AddDependenciasConfig(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserIdentity, UserIdentity>();

            //Repositórios
            services.AddTransient<ICliente, ClienteRepository>();
            services.AddTransient<ISaque, SaqueRepository>();
            services.AddTransient<ITransferencia, TransferenciaRepository>();
            services.AddTransient<IDeposito, DepositoRepository>();
            services.AddTransient<IUsuario, LoginRepository>();

            //Handler
            services.AddTransient<ClienteHandler, ClienteHandler>();
            services.AddTransient<SaqueHandler, SaqueHandler>();
            services.AddTransient<TransferenciaHandler, TransferenciaHandler>();
            services.AddTransient<DepositoHandler, DepositoHandler>();
            services.AddTransient<UsuarioHandler, UsuarioHandler>();

            //Services
            services.AddScoped<IClientesService, ClientesService>();
            services.AddScoped<ISaquesService, SaqueService>();
            services.AddScoped<ITransferenciaService, TransfereneciaService>();
            services.AddScoped<IDepositoService, DepositoService>();


            return services;
        }
    }
}
