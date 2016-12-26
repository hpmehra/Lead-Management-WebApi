using IC.LMS.Business;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using IC.LMS.WebApi.Constant;

namespace IC.LMS.WebApi.OAuthProvider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            UserLoginImpl _repo = new UserLoginImpl();
            UserDetailImpl _userDetailImpl = new UserDetailImpl();

            IdentityUser user = await _repo.FindUser(context.UserName, context.Password);
            var result = _userDetailImpl.GetUserDetailsByUsername(context.UserName);
            if (user == null || result == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }


            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(Constants.userName, context.UserName));
            identity.AddClaim(new Claim(Constants.userID, result.UserId.ToString()));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);

        }
    }
}