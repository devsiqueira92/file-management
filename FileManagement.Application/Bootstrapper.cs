using FileManagement.Application.UseCases.FileDownloadUseCase;
using FileManagement.Application.UseCases.FileReadUseCase;
using FileManagement.Application.UseCases.FileUploadUseCase;
using FileManagement.Application.UseCases.FolderCreateUseCase;
using FileManagement.Application.UseCases.FolderReadUseCase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FileManagement.Application
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddTokenConfiguration(services, configuration);
            AddUseCases(services);
            AddServices(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IFolderCreateUseCase, FolderCreateUseCase>()
                .AddScoped<IFolderReadUseCase, FolderReadUseCase>()
                .AddScoped<IFileReadUseCase, FileReadUseCase>()
                .AddScoped<IFileUploadUseCase, FileUploadUseCase>()
                .AddScoped<IFileDownloadUseCase, FileDownloadUseCase>();
        }

        private static void AddTokenConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "localhost",
                    ValidAudience = "localhost",
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(configuration.GetSection("Secrets:SecurityKey").Value))
                };

            });

            //var sectionTempoDeVida = configuration.GetRequiredSection("Configuracoes:Jwt:TempoVidaTokenMinutos");
            //var sectionKey = configuration.GetRequiredSection("Secrets:SecurityKey");
            //services.AddScoped<ITokenController>(option => new TokenController(int.Parse(sectionTempoDeVida.Value), sectionKey.Value));
        }

        private static void AddServices(IServiceCollection services)
        {
            //services.AddScoped<ILoggedUser, LoggedUser>();
        }

    }
}
