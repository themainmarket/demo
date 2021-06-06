using E_BookLibrary.Policy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_BookLibrary.Extensions
{
    public static class AuthorizationServiceExtension
    {
        public static void ConfigureAuthorizationPolicy(this IServiceCollection service)
        {
            service.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                options.AddPolicy(Policies.RegularUser, Policies.RegularUserPolicy());
            });
        }
    }
}
