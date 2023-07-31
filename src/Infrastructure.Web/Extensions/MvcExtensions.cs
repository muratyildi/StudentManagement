using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Infrastructure.Web.Extensions
{
    public static class MvcExtensions
    {
        public static IDictionary<string, string[]> GetErrors(this ModelStateDictionary modelState)
        {
            var errorList = modelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );

            return errorList;
        }
    }
}
