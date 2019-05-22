using System;

namespace Building.A.RESTful.API.With.NancyFx
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid Identifier { get; set; }
    }
}
