using BitirmeProjesi.Data.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Infrastructure.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ApiExceptionHandlingMiddleware>();
    }
}
