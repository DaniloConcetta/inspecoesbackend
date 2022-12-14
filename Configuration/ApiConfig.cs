
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
using NetDevPack.Security.JwtSigningCredentials.AspNetCore;
using Inspecoes.Services;
//using AutoMapper.EquivalencyExpression;


namespace Inspecoes.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
          
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

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

            services.AddHostedService<TimedHostedService>();

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
              //app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
              //app.UseCors("Production"); 
                app.UseHsts();
            }

            //app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
           
            app.UseAuthentication();
            app.UseAuthorization();
            // app.UseStaticFiles();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                /*
                endpoints.MapHealthChecks("/api/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecksUI(options =>
                {
                    options.UIPath = "/api/hc-ui";
                    options.ResourcesPath = "/api/hc-ui-resources";

                    options.UseRelativeApiPath = false;
                    options.UseRelativeResourcesPath = false;
                    options.UseRelativeWebhookPath = false;
                });
                */
            });
            

            app.UseJwksDiscovery("/jwks");
            return app;
        }
    }
}