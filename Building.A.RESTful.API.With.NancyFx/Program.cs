using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nancy.Owin;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Building.A.RESTful.API.With.NancyFx;

internal class Program
{
    private static void PopulateRepositories()
    {
        PersonRepository.Instance.Add(new Person { Id = 1, FirstName = "Danut", LastName = "Radoaica" });
        UserRepository.Instance.Add(new User { UserName = "dradoaica", Password = "1234", Identifier = Guid.NewGuid() });
    }

    private static void Main()
    {
        MainAsync().GetAwaiter().GetResult();
    }

    private static async Task MainAsync()
    {
        _ = ConfigurationManager.AppSettings.AllKeys;
        string url = "http://+:8984";
        IHostBuilder hostBuilder = new HostBuilder()
            .UseEnvironment(Environments.Development)
            .ConfigureServices(services =>
            {
                _ = services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });
                _ = services.Configure<IISServerOptions>(options => { options.AllowSynchronousIO = true; });
                PopulateRepositories();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                _ = webBuilder.UseUrls(url);
                _ = webBuilder.UseStartup<Startup>();
            });
        IHost host = hostBuilder.Build();
        using (host)
        {
            await host.RunAsync().ConfigureAwait(false);
        }
    }

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            _ = app.UseOwin(pipeline =>
            {
                NancyOptions options = new()
                {
                    Bootstrapper = new Bootstrapper()
                };
                _ = pipeline.UseNancy(options);
            });
        }
    }
}