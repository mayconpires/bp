using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using BP.API.Shared.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Examples;

namespace BP.API
{
    public partial class Startup
    {

        private void ConfigureSwaggerService(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                string basePath = PlatformServices.Default.Application.ApplicationBasePath;
                string moduleName = GetType().GetTypeInfo().Module.Name.Replace(".dll", ".xml");
                string filePath = Path.Combine(basePath, moduleName);
                string readme = File.ReadAllText(Path.Combine(basePath, "README.md"));

                ApiKeyScheme scheme = Configuration.GetSection("DocumentacaoPublica:ApiKeyScheme").Get<ApiKeyScheme>();
                options.AddSecurityDefinition("Authentication", scheme);

                Info info = Configuration.GetSection("DocumentacaoPublica:Info").Get<Info>();
                info.Description = readme;
                options.SwaggerDoc(info.Version, info);

                options.IncludeXmlComments(filePath);
                options.DescribeAllEnumsAsStrings();
                options.OperationFilter<ExamplesOperationFilter>();
                options.DocumentFilter<HideInDocsFilter>();
            });
        }

        private void ConfigureSwagger(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs"));
            }

            app.UseSwagger(c => c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value));
        }

    }
}
