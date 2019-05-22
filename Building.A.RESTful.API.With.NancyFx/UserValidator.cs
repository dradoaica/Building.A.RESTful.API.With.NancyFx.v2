using Nancy.Authentication.Basic;
using System.Collections.Generic;
using System.Security.Claims;

namespace Building.A.RESTful.API.With.NancyFx
{
    public class UserValidator : IUserValidator
    {
        public ClaimsPrincipal Validate(string username, string password)
        {
            // null == anonymous
            ClaimsPrincipal ret = null;
            foreach (User user in UserRepository.Instance.GetAll())
            {
                if (user.UserName == username && user.Password == password)
                {
                    ret = new UserIdentity(user.UserName, user.Identifier, new List<string> { UserIdentity.HANDLEPERSON_PERMISSION });
                }
            }

            return ret;
        }
    }
}
