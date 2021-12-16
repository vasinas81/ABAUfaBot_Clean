using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ABAUfaBot.Application
{
    public static class AppDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
