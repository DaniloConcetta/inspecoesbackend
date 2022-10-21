using Inspecoes.Interfaces;
//using Inspecoes.Notifications;
//using Inspecoes.Services;
using Inspecoes.Data;
using Inspecoes.Repository;
using Microsoft.Extensions.Options;

//using Inspecoes.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Inspecoes.Services;
using Inspecoes.Notifications;

namespace Inspecoes.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            //   services.AddScoped<AppIdentityDbContext>();

            services.AddScoped<IGrupoPerguntaRepository, GrupoPerguntaRepository>();
            services.AddScoped<IPerguntaRepository, PerguntaRepository>();
            services.AddScoped<IGrupoPerguntaService, GrupoPerguntaService>();
            services.AddScoped<IGrupoProdutoRepository, GrupoProdutoRepository>();

            //      services.AddScoped<IUserRepository, UserRepository>();
            //     services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            services.AddScoped<INotifier, Notifier>();
            //     services.AddScoped<IUserService, UserService>();
            //    services.AddScoped<IUserProfileService, UserProfileService>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //    services.AddScoped<IUser, AspNetUser>();

         //   services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}