using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Building.A.RESTful.API.With.NancyFx
{
    public class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
            Formatting = Formatting.Indented;
        }
    }
}
