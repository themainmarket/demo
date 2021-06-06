using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_BookLibrary.Policy
{
    public class AuthorizeMultiplePolicyAttribute : TypeFilterAttribute
    {
        public AuthorizeMultiplePolicyAttribute(string[] policies):base(typeof(AuthorizeMultiplePolicyFilter))
        {
            Arguments = new object[] { policies };
        }
    }
}
