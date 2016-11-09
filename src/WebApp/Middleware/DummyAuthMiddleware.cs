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
using Microsoft.AspNetCore.DataProtection;

namespace WebApp.Middleware
{
    public class DummyAuthMiddleware : AuthenticationMiddleware<DummyAuthOptions>
    {
        public DummyAuthMiddleware(
            RequestDelegate next,
            IOptions<DummyAuthOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder,
            IOptions<SharedAuthenticationOptions> sharedOptions,
            IDataProtectionProvider dataProtectionProvider) : 
            base(next, options, loggerFactory, encoder)
        {
            if(string.IsNullOrEmpty(options.Value.SignInScheme))
            {
                options.Value.SignInScheme = sharedOptions.Value.SignInScheme;
            }

            if(options.Value.SecureDataFormat == null)
            {
                var dataProtector = dataProtectionProvider
                    .CreateProtector(typeof(DummyAuthMiddleware).FullName);

                options.Value.SecureDataFormat = new PropertiesDataFormat(dataProtector);
            }
        }

        protected override AuthenticationHandler<DummyAuthOptions> CreateHandler()
        {
            return new DummyAuthHandler();
        }
    }
}
