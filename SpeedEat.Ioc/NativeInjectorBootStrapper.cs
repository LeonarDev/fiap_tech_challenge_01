using FluentNHibernate.Cfg;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using SpeedEat.Aplicacao;
using SpeedEat.Aplicacao.Clientes.Servico;
using SpeedEat.Infra.Clientes.Mapeamentos;
using SpeedEat.Infra.Clientes.Repositorios;
using SpeedEat.Dominio.Clientes.Servicos;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace SpeedEat.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISessionFactory>(factory =>
            {
                return Fluently.Configure().Database(() =>
                {
                    string connectionString = configuration.GetConnectionString("Oracle");

                    return FluentNHibernate.Cfg.Db.OracleManagedDataClientConfiguration.Oracle10
                        .FormatSql()
                        .ShowSql()
                        .ConnectionString(connectionString);
                }).Mappings(m => m.FluentMappings.AddFromAssemblyOf<ClienteMap>())
                  .CurrentSessionContext("call")
                  .BuildSessionFactory();
            });

            services.AddScoped<NHibernate.ISession>(factory =>
            {
                return factory.GetService<ISessionFactory>().OpenSession();
            });


            services.AddSingleton<IHttpContextAccessor, IHttpContextAccessor>();
            
            services.AddAutoMapper(typeof(ClientesProfile).GetTypeInfo().Assembly);

            services.Scan(scan => scan
                .FromAssemblyOf<ClientesAppServico>()
                    .AddClasses()
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<ClientesRepositorio>()
                    .AddClasses()
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<ClientesServico>()
                    .AddClasses()
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());
        }
    }
}