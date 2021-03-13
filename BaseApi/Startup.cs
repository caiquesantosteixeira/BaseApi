using Base.API.Configuracoes;
using Base.Infra.Context;
using Base.Infra.Helpers.Configuracoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Reflection;

namespace BaseApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            string conexao = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BaseContext>(a => a.UseSqlServer(conexao));

            // configuração do Identity
            //services.AddIdentityConfig(Configuration, tipoBanco);

            // Injeção de dependencias
            services.AddDependenciasConfig();

            // Adiciona as instancias de alguns serviços
            services.AddIntanciaServiceConfig();

            //Rodas as Migraçoes do Identity
            //InicializaDatabase.ExecutaIdentityMigrations();

            // Roda os Migrations
            //MigrationsDataBase.RunMigration(conexao, tipoBanco);

            services.AddCors(o => o.AddPolicy("EnableCors", builder => {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            }));

            //Swagger
            services.ConfiguraSwagger($"{Assembly.GetExecutingAssembly().GetName().Version}");

            services.AddMvc();
            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "documentacao";
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Projeto Base");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "index.html");
            app.UseRewriter(option);

            ////Rodas as Migraçoes do Identity
            //InicializaDatabase.InicializarBanco(app.ApplicationServices);

            var cultureInfo = new CultureInfo("pt-BR");
            cultureInfo.NumberFormat.CurrencySymbol = "R$";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("EnableCors");

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
