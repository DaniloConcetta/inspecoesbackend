using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Inspecoes.Services;
using Inspecoes.Notifications;
using Inspecoes.Interfaces;
using Inspecoes.Data;
using Inspecoes.Repository;
using Inspecoes.Extensions;
using Inspecoes.Utils;
//using Inspecoes.Notifications;
//using Inspecoes.Services;

namespace Inspecoes.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            // services.AddScoped<AppIdentityDbContext>();

            services.AddScoped<ITipoPerguntaRepository, TipoPerguntaRepository>(); 
            services.AddScoped<ITipoPerguntaService, TipoPerguntaService>();
            services.AddScoped<IPerguntaRepository, PerguntaRepository>();
            services.AddScoped<IPerguntaService, PerguntaService>();
            services.AddScoped<IGrupoPerguntaRepository, GrupoPerguntaRepository>();
            services.AddScoped<IGrupoPerguntaPerguntaRepository, GrupoPerguntaPerguntaRepository>();
            services.AddScoped<IGrupoPerguntaGrupoProdutoRepository, GrupoPerguntaGrupoProdutoRepository>();
            services.AddScoped<IGrupoPerguntaService, GrupoPerguntaService>();
            services.AddScoped<IGrupoProdutoRepository, GrupoProdutoRepository>();

            services.AddScoped<IOpRepository, OpRepository>();
            services.AddScoped<IOpService, OpService>();

            services.AddScoped<IStatusInspecaoRepository, StatusInspecaoRepository>();
            services.AddScoped<IStatusInspecaoService, StatusInspecaoService>();
            services.AddScoped<IInspecaoRepository, InspecaoRepository>();
            services.AddScoped<IInspecaoService, InspecaoService>();
            services.AddScoped<IInspecaoItemRepository, InspecaoItemRepository>();
            services.AddScoped<IInspecaoItemService, InspecaoItemService>();
            services.AddScoped<IInspecaoLaudoService, InspecaoLaudoService>();

            services.AddScoped<IGrupoProdutoService, GrupoProdutoService>();

            // services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IFileUtil, FileUtil>();
            services.AddScoped<INotifier, Notifier>();
            // services.AddScoped<IUserService, UserService>();
            // services.AddScoped<IUserProfileService, UserProfileService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AuthService>();
            services.AddScoped<IUser, AspNetUser>(); 

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddHttpClient<IGruposProdutoPService, GruposProdutoPService>();
            services.AddHttpClient<IOpPService, OpPService>();

            return services;
        }
    }
}