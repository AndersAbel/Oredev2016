using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;

namespace WebApp.Middleware
{
    public class DummyAuthHandler : RemoteAuthenticationHandler<DummyAuthOptions>
    {
        static AuthenticationProperties _properties;

        protected override Task<bool> HandleUnauthorizedAsync(ChallengeContext context)
        {
            var path = Options.CallbackPath + "?"
                + string.Join("&", context.Properties.Select(kv =>
                UrlEncoder.Encode(kv.Key) + "=" + UrlEncoder.Encode(kv.Value)));

            Response.Redirect(path);
            return Task.FromResult(true);
        }

        protected override Task<AuthenticateResult> HandleRemoteAuthenticateAsync()
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "42"));
            identity.AddClaim(new Claim(ClaimTypes.Name, "Anders"));
            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties(
                Request.Query.ToDictionary(qp => qp.Key, qp => qp.Value.Single()));

            var ticket = new AuthenticationTicket(principal, properties, Options.SignInScheme);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
