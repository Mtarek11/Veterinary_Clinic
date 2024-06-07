using Microsoft.IdentityModel.Logging;
using Serilog;
using Serilog.Context;
using System.Security.Claims;

namespace API.Extensions
{
    public static class ConfigurationUseLoggerExtension
    {
        public static void ConfigurationUseLogger(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var adminId = context.User?.Identity!.IsAuthenticated == true ? context.User!.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anonymous" : "Anonymous";
                Log.Information("Admin: {@adminId}", adminId);
                await next();
            });
        }
    }
}
