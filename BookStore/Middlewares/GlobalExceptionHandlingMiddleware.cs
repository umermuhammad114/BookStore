
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace BookStore.Middlewares
{
    public class GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var problem = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = "Server Error",
                    Type = "Server Error",
                    Detail = "An internal server error occured in the request."
                };

                var json = JsonSerializer.Serialize(problem);

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);

            }
        }
    }
}
