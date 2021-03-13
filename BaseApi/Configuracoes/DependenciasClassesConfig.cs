//using Base.Domain.Handler.Cliente;
//using Base.Domain.Handler.Menu;
//using Base.Domain.Handler.Produto;
//using Base.Domain.Handler.Usuario;
//using Base.Domain.Repositorios.Cliente;
//using Base.Domain.Repositorios.Logging;
//using Base.Domain.Repositorios.Menu;
//using Base.Domain.Repositorios.Produto;
//using Base.Domain.Repositorios.Shared;
//using Base.Domain.Repositorios.Usuarios;
//using Base.Domain.Services.Cliente;
//using Base.Domain.Services.Produto;
//using Base.Infra.Repositorios.Cliente;
//using Base.Infra.Repositorios.Log;
//using Base.Infra.Repositorios.Menu;
//using Base.Infra.Repositorios.Produto;
//using Base.Infra.Repositorios.Shared;
//using Base.Infra.Repositorios.Usuarios;
//using Base.Infra.Services.Cliente;
//using Base.Infra.Services.Produto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Base.API.Configuracoes
{
    public static class DependenciasClassesConfig
    {
        public static IServiceCollection AddDependenciasConfig(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUserIdentity, UserIdentity>();

            // Repositórios
            //services.AddTransient<IUsuario, LoginRepository>();
            //services.AddTransient<IPerfilUsuario, PerfilUsuarioRepository>();
            //services.AddTransient<IPerfil, PerfilRepository>();
            //services.AddTransient<IMenuOpcoes, MenuOpcoesRepository>();
            //services.AddTransient<IPermissoes, PermissoesRepository>();
            //services.AddTransient<IPerfilUsuarioBotoes, PerfilUsuarioBotoesRepository>();
            //services.AddTransient<IMenu, MenuRepository>();
            //services.AddTransient<IMenuOpcoesBotoes, MenuOpcoesBotoesRepository>();
            //services.AddTransient<ILog, LogRepository>();
            //services.AddScoped<IMunicipios, MunicipiosRepository>();
            //services.AddSingleton<IImagens, ImagensRepository>();
            //services.AddScoped<ICategoriasCliente, CategoriasClienteRepository>();
            //services.AddScoped<IClientes, ClienteRepository>();
            //services.AddScoped<IClientesUsuarios, ClientesUsuariosRepository>();
            //services.AddScoped<ICategoriasProduto, CategoriasProdutoRepository>();
            //services.AddScoped<IProdutos, ProdutosRepository>();

            // Handler
            //services.AddTransient<UsuarioHandler, UsuarioHandler>();
            //services.AddTransient<PerfilUsuarioHandler, PerfilUsuarioHandler>();
            //services.AddTransient<PerfilHandler, PerfilHandler>();
            //services.AddTransient<MenuOpcoesHandler, MenuOpcoesHandler>();
            //services.AddTransient<PerfilUsuarioBotoesHandler, PerfilUsuarioBotoesHandler>();
            //services.AddTransient<MenuHandler, MenuHandler>();
            //services.AddTransient<MenuOpcoesBotoesHandler, MenuOpcoesBotoesHandler>();
            //services.AddTransient<CategoriasClienteHandler, CategoriasClienteHandler>();
            //services.AddTransient<ClientesHandler, ClientesHandler>();
            //services.AddTransient<ClientesUsuariosHandler, ClientesUsuariosHandler>();
            //services.AddTransient<CategoriasProdutoHandler, CategoriasProdutoHandler>();
            //services.AddTransient<ProdutosHandler, ProdutosHandler>();

            // Services
            //services.AddScoped<IClientesService, ClientesService>();
            //services.AddScoped<ICategoriasClienteService, CategoriasClienteService>();
            //services.AddScoped<IProdutosService, ProdutosService>();
            //services.AddScoped<ICategoriasProdutoService, CategoriasProdutoService>();


            return services;
        }
    }
}
