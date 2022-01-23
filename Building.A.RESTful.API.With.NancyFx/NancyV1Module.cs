using Nancy;

namespace Building.A.RESTful.API.With.NancyFx;

public abstract class NancyV1Module : NancyModule
{
    protected NancyV1Module()
    {
    }

    protected NancyV1Module(string modulePath)
        : base(modulePath)
    {
    }

    public new NancyV1RouteBuilder Get => new(this, NancyV1RouteBuilder.HttpMethod.Get);
    public new NancyV1RouteBuilder Put => new(this, NancyV1RouteBuilder.HttpMethod.Put);
    public new NancyV1RouteBuilder Post => new(this, NancyV1RouteBuilder.HttpMethod.Post);
    public new NancyV1RouteBuilder Patch => new(this, NancyV1RouteBuilder.HttpMethod.Patch);
    public new NancyV1RouteBuilder Delete => new(this, NancyV1RouteBuilder.HttpMethod.Delete);
    public new NancyV1RouteBuilder Head => new(this, NancyV1RouteBuilder.HttpMethod.Head);
    public new NancyV1RouteBuilder Options => new(this, NancyV1RouteBuilder.HttpMethod.Options);
}