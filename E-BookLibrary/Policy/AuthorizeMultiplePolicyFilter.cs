using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_BookLibrary.Policy
{
    public class AuthorizeMultiplePolicyFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _auhtorization;

        public string[] _policies { get; private set; }

        public AuthorizeMultiplePolicyFilter(string[] policies, IAuthorizationService auhtorization)
        {
            _policies = policies;

            _auhtorization = auhtorization;
        }


        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            foreach(var policy in _policies)
            {
                var authorized = await _auhtorization.AuthorizeAsync(context.HttpContext.User, policy);

                if (authorized.Succeeded)
                {
                    return;
                }
            }

            context.Result = new ForbidResult();

            return;
        }
    }
}
