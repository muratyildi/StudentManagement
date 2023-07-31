using System;
using System.Linq;
using System.Security.Claims;
using Infrastructure.Web.Constants;

namespace Infrastructure.Web.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetClaimValue(this ClaimsPrincipal principle, string type)
        {
            return principle.Claims.Where(x => x.Type == type).Take(1).SingleOrDefault()?.Value;
        }

        public static long GetAccountId(this ClaimsPrincipal principle)
        {
            return Convert.ToInt64(principle.Claims?.Where(x => x.Type == ClaimDefaults.AccountId).Take(1).SingleOrDefault()?.Value ?? "0");
        }
    }
}