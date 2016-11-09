using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Middleware
{
    public class DummyAuthOptions : RemoteAuthenticationOptions
    {
        public DummyAuthOptions()
        {
            AuthenticationScheme = "Dummy";
            CallbackPath = "/signin-dummy";
            DisplayName = "Dummy";
        }

        public ISecureDataFormat<AuthenticationProperties>  SecureDataFormat { get; set; }
    }
}
