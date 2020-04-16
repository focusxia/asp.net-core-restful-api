using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetRestFulWebApi.Helper
{
    public static class CustomMiddlewareExtensions
    {
        public static void CustomExceptionMiddleware(this IApplicationBuilder builder) {
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
