using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace OfficeAuthomation.Presentation.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = (int) context.Response.StatusCode;
            var result = JsonConvert.SerializeObject(
                new
                {
                    source = ex.Source,
                    error = ex.Message
                });
            context.Response.ContentType = "application/json";


            Log.ForContext("Message", ex.Message)
                .Error($"Error: {result} StatusCode: {statusCode}");

            return context.Response.WriteAsync(result);
        }
    }

}

