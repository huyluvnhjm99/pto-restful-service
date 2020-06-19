using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using pto_restful_service.Repository;
using System.Diagnostics;
using System.Web.Security;

namespace pto_restful_service.Models
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (UserRepository _repo = new UserRepository())
            {
                var user = _repo.ValidateUser(context.UserName);
                Debug.WriteLine("Gmail: " + user.gmail);
                Debug.WriteLine("Name: " + user.name);
                Debug.WriteLine("Role: " + user.role);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Provided gmail is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, user.role));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.name));
                identity.AddClaim(new Claim("Email", user.gmail));
                identity.AddClaim(new Claim("Role", user.role));
                context.Validated(identity);
            }
        }
    }
}