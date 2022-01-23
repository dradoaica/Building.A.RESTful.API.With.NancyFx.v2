using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nancy.Owin;

namespace Building.A.RESTful.API.With.NancyFx;

internal class Program
{
    private static void PopulateRepositories()
    {
        PersonRepository.Instance.Add(new Person {Id = 1, FirstName = "Danut", LastName = "Radoaica"});
        UserRepository.Instance.Add(new User {UserName = "dradoaica", Password = "1234", Identifier = Guid.NewGuid()});
    }

    private static void Main()
    {
        MainAsync().GetAwaiter().GetResult();
    }

    private static async Task MainAsync()
    {
        _ = ConfigurationManager.AppSettings.AllKeys;
        var url = "http://+:8984";
        IHostBuilder hostBuilder = new HostBuilder()
            .UseEnvironment(Environments.Development)
            .ConfigureServices(services =>
            {
                services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });
                services.Configure<IISServerOptions>(options => { options.AllowSynchronousIO = true; });
                PopulateRepositories();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseUrls(url);
                webBuilder.UseStartup<Startup>();
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
            app.UseOwin(pipeline =>
            {
                var options = new NancyOptions
                {
                    Bootstrapper = new Bootstrapper()
                };
                pipeline.UseNancy(options);
            });
        }
    }
}