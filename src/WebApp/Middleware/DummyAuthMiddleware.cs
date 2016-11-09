using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace WebApp.Middleware
{
    public class DummyAuthMiddleware : AuthenticationMiddleware<DummyAuthOptions>
    {
        public DummyAuthMiddleware(
            RequestDelegate next,
            IOptions<DummyAuthOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder,
            IOptions<SharedAuthenticationOptions> sharedOptions) : 
            base(next, options, loggerFactory, encoder)
        {
            if(string.IsNullOrEmpty(options.Value.SignInScheme))
            {
                options.Value.SignInScheme = sharedOptions.Value.SignInScheme;
            }
        }

        protected override AuthenticationHandler<DummyAuthOptions> CreateHandler()
        {
            return new DummyAuthHandler();
        }
    }
}
