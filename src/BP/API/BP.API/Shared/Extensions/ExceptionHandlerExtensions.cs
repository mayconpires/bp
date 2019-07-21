using CorrelationId;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.API.Shared.Extensions
{
    public static class ExceptionHandlerExtensions
    {

        /// <summary>
        /// Midleware para capturar as exceptions.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app, IConfiguration configuration, IHostingEnvironment env)
        {
            ICorrelationContextAccessor correlationContextAccessor = (ICorrelationContextAccessor)app.ApplicationServices.GetService(typeof(ICorrelationContextAccessor));

            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var problemDetails = new ProblemDetails
                        {
                            Instance = context.Request.HttpContext.Request.Path
                        };

                        context.Response.StatusCode = context.Response.StatusCode;
                        context.Response.ContentType = "application/problem+json";

                        problemDetails.Title = exceptionHandlerFeature.Error.Message;
                        problemDetails.Status = StatusCodes.Status500InternalServerError;
                        problemDetails.Detail = exceptionHandlerFeature.Error.ToString();

                        Serilog.Log.ForContext("Operacao", "Processamento", destructureObjects: true)
                                .Error($"Erro: {JsonConvert.SerializeObject(problemDetails)}");

                        problemDetails.Detail = "Problema no processamento.";

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
                    }
                });
            });
        }

    }
}
