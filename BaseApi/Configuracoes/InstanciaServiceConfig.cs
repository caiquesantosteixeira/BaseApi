using Base.Infra.Context;
using Base.Infra.Context.BaseContext;
using Base.Infra.Helpers;
using BaseApi;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Base.API.Configuracoes
{
    public static class InstanciaServiceConfig
    {
        public static IServiceCollection AddIntanciaServiceConfig(this IServiceCollection services)
        {
           
            var serviceProvider = services.BuildServiceProvider();
            var serv1 = serviceProvider.GetService<BaseContext>();
            LocalizarService.Registrar<BaseContext>("DataContext", serv1);

            //var serv2 = serviceProvider.GetService<ILog>();
            //LocalizarService.Registrar<ILog>("ILog", serv2);

            var serv3 = serviceProvider.GetService<IdentityDataContext>();
            LocalizarService.Registrar<IdentityDataContext>("IdentityDataContext", serv3);

            return services;
        }
    }
}
