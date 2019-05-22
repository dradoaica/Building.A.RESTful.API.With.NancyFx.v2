using Microsoft.Owin.Hosting;
using Nancy.Owin;
using Owin;
using System;

namespace Building.A.RESTful.API.With.NancyFx
{
    internal class Program
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                NancyOptions options = new NancyOptions
                {
                    Bootstrapper = new Bootstrapper()
                };
                app.UseNancy(options);
            }
        }

        private static void PopulateRepositories()
        {
            PersonRepository.Instance.Add(new Person { Id = 1, FirstName = "Danut", LastName = "Radoaica" });
            UserRepository.Instance.Add(new User { UserName = "dradoaica", Password = "1234", Identifier = Guid.NewGuid() });
        }

        private static void Main(string[] args)
        {
            string url = "http://+:8080";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on {0}", url);

                PopulateRepositories();

                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
}
