using Microsoft.AspNetCore.Diagnostics;
using System.Net.Mime;
using System.Net;
using System.Text.Json;
using Application.Exceptions;
using Serilog;

namespace API.Extensions
{
    public static class ConfigurationExceptionHandlerExtension
    {
        public static void ConfigurationExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        var exception = contextFeature.Error;

                        context.Response.ContentType = MediaTypeNames.Application.Json;

                        // Determine the status code based on the exception type
                        context.Response.StatusCode = exception switch
                        {
                            NotFoundUserException => (int)HttpStatusCode.NotFound,
                            AuthenticationException => (int)HttpStatusCode.Unauthorized,
                            NotFoundEntityException => (int)HttpStatusCode.NotFound,
                            _ => (int)HttpStatusCode.InternalServerError,
                        };

                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            Title = "An error occurred!",
                            Message = exception.Message,
                            StatusCode = context.Response.StatusCode
                        }));
                    }
                });
            });
        }
    }
}
