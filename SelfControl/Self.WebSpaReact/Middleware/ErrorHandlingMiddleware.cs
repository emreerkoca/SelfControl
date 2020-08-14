using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Self.WebSpaReact.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Self.WebSpaReact.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment environment)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, environment);
            }
        }

        public static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment environment)
        {
            HttpStatusCode statusCode;
            string message;
            var stackTrace = String.Empty;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(BadRequestException))
            {
                message = exception.Message;
                statusCode = HttpStatusCode.BadRequest;
            } 
            else if (exceptionType == typeof(NotFoundException))
            {
                message = exception.Message;
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = exception.Message;

                if (environment.IsDevelopment())
                {
                    stackTrace = exception.StackTrace;
                }
            }

            var result = JsonSerializer.Serialize(new { error = message, stackTrace });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
