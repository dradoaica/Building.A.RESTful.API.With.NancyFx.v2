using Nancy;

namespace Building.A.RESTful.API.With.NancyFx
{
    public abstract class NancyV1Module : NancyModule
    {
        public new NancyV1RouteBuilder Get => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Get);
        public new NancyV1RouteBuilder Put => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Put);
        public new NancyV1RouteBuilder Post => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Post);
        public new NancyV1RouteBuilder Patch => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Patch);
        public new NancyV1RouteBuilder Delete => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Delete);
        public new NancyV1RouteBuilder Head => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Head);
        public new NancyV1RouteBuilder Options => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Options);

        protected NancyV1Module()
            : base()
        {
        }

        protected NancyV1Module(string modulePath)
            : base(modulePath)
        {
        }
    }
}
