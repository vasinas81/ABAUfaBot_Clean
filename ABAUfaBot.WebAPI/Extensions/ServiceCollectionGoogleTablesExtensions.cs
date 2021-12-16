using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Infrastructure.ABATableProviders;
using ABAUfaBot.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABAUfaBot.WebAPI.Extensions
{
    public static class ServiceCollectionGoogleTablesExtensions
    {
        public static IServiceCollection SetupGoogleTables(this IServiceCollection service, IConfiguration configuration)
        {
            var googleTableServiceOptions = configuration.GetSection(nameof(ABAGoogleTableServiceOptions)).Get<ABAGoogleTableServiceOptions>();
            
            service.AddSingleton<IABAGoogleTableService>(g => new ABAGoogleTableService(googleTableServiceOptions));
            service.AddSingleton<IUserABATableProvider, UserABATableProvider>();
            
            return service;
        }
    }
}
