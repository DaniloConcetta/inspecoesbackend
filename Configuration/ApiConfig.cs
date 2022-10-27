
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Inspecoes.Extensions;
using System.Text.Json.Serialization;
//using AutoMapper.EquivalencyExpression;


namespace Inspecoes.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));

            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            }); // xttps://stackoverflow.com/questions/40334515/automatically-generate-lowercase-dashed-routes-in-asp-net-core 

            services.AddControllers().AddJsonOptions(options =>
            { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .AllowCredentials()
                            .SetIsOriginAllowed(origin => true)
                            .AllowAnyMethod()
                            .AllowAnyHeader());

                //.WithMethods("GET")
                //.WithOrigins("http://desenvolvedor.io")
                //.SetIsOriginAllowedToAllowWildcardSubdomains()
                ////.WithHeaders(HeaderNames.ContentType, "x-custom-header")
                //.AllowAnyHeader());
                //VERIFICAR CORS - FUTURAMENTE
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Production"); // Usar apenas nas demos => Configuração Ideal: Production
                app.UseHsts();
            }

            //app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            return app;
        }
    }
}