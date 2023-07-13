using Microsoft.AspNetCore;
using Serilog;
using SpeedEat.API;

internal class Program
{
    public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    public static void Main(string[] args)
    {
        //Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();

        try
        {
            //Log.Information("Iniciando aplicação...");

            BuildWebHost(args).Run();
        }
        catch (Exception ex)
        {
            //Log.Error(ex, "Host encerrado de maneira inesperada!");
        }
        finally
        {
            //Log.CloseAndFlush();
        }
    }

    public static IWebHost BuildWebHost(string[] args)
    {
        string portaBind = Configuration.GetSection("Aplicacao:Porta").Value;

        var builder = WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseConfiguration(Configuration)
            .UseUrls(portaBind);

        return builder.Build();
    }
}