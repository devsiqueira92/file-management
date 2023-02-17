using FileManagement.Domain.RepositoryInterface;
using FileManagement.Infrastructure.Context;
using FileManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileManagement.Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configurationManager)
        {
            AddContexto(services, configurationManager);
            AddRepositories(services, configurationManager);
        }

        private static void AddContexto(IServiceCollection services, IConfiguration configurationManager)
        {
            services.AddDbContext<FileManagementContext>(dbContext =>
            {
                dbContext.UseSqlServer(configurationManager.GetConnectionString("Connection"));
            });
        }

        private static void AddRepositories(IServiceCollection services, IConfiguration configurationManager)
        {
            string basePath = configurationManager.GetSection("Folder:BasePath").Value;

            services.AddScoped<IFolderRepository>(opt => new FolderRepository(basePath))
                .AddScoped<IFileRepository>(opt => new FileRepository(basePath));
        }
    }
}
