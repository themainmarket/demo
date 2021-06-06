using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_BookLibrary.Policy
{
    public static class Policies
    {
        public  const string Admin = "Admin";

        public  const string RegularUser = "RegularUser";
        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();

        }

        public static AuthorizationPolicy RegularUserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(RegularUser).Build();
        }
    }
}
