using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Common.RangeProviders;

namespace ABAUfaBot.Application
{
    public static class AppDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IABATableRangeProvider, ABATableRangeProvider>();
            return services;
        }
    }
}
