﻿
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.IdentityModel.Xml;

namespace STSys.Core.Data.IoC
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Api V1");
                c.RoutePrefix = string.Empty;
            });
        }

        public static void AddSwaggerService(this IServiceCollection services, string title, string description, string xmlpath)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = title,
                    Description = description
                });
                c.SwaggerDoc("v2", new Info { Title = "Core Api V2", Version = "v2" });
                c.DescribeAllEnumsAsStrings();

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlpath);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
