﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BP.API.Shared.Extensions;
using BP.API.Shared.Validation;
using BP.Application.Services.Core;
using BP.Domain.Shared.Attributes;
using BP.Interface.Application.Core.MDR;
using BP.Interface.Application.Core.Transaction;
using BP.IoC.Setup;
using BP.Models.Shared.Json;
using CorrelationId;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BP.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
            });

            services.AddMvc(options =>
                {
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = false });
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressUseValidationProblemDetailsForInvalidModelStateResponses = true;

                });

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            ConfigureSwaggerService(services);

            Injector.RegisterServices(services: services, configuration: Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    //app.UseHsts();
            //    //app.UseHttpsRedirection();
            //}
            app.UseStaticFiles();

            app.UseGlobalExceptionHandler(Configuration, env);

            ConfigureSwagger(app, env);

            app.UseMvc();
        }
    }
}
