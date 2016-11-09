using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Middleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class DummyAppBuilderExtensions
    {
        public static IApplicationBuilder UseDummyAuthentication(this IApplicationBuilder app)
        {
            app.UseMiddleware<DummyAuthMiddleware>(Options.Create(new DummyAuthOptions()));

            return app;
        }
    }
}
