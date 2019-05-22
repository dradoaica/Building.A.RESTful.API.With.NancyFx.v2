using Nancy;
using Nancy.Authentication.Basic;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Newtonsoft.Json;

namespace Building.A.RESTful.API.With.NancyFx
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<JsonSerializer, CustomJsonSerializer>();
            container.Register<IUserValidator, UserValidator>();
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.EnableBasicAuthentication(new BasicAuthenticationConfiguration(
                container.Resolve<IUserValidator>(),
                "MyRealm"));

            pipelines.OnError += (ctx, e) =>
            {
                return new Response().WithStatusCode(HttpStatusCode.InternalServerError);
            };
            pipelines.BeforeRequest += ctx =>
            {
                return null;
            };
            pipelines.AfterRequest += ctx =>
            {
            };
        }
    }
}
