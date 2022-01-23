using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Building.A.RESTful.API.With.NancyFx;

public class UserIdentity : ClaimsPrincipal
{
    internal const string HANDLEPERSON_PERMISSION = "HandlePerson";

    public UserIdentity(string userName, Guid userIdentifier, IEnumerable<string> claims)
    {
        UserName = userName;
        UserIdentifier = userIdentifier;
        var claimList = new List<Claim>();
        foreach (string claim in claims) claimList.Add(new Claim(ClaimTypes.Role, claim));
        AddIdentity(new ClaimsIdentity(claimList, "Basic"));
    }

    public string UserName { get; }
    public Guid UserIdentifier { get; }

    public bool HasClaim(string claim)
    {
        return Claims.Any(c => c.Value == claim);
    }
}