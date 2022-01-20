using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Common.RangeProviders;
using ABAUfaBot.Application.BotCommands;

namespace ABAUfaBot.Application
{
    public static class AppDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IABATableRangeProvider, ABATableRangeProvider>();
            services.AddABABotCommandsServices();
            return services;
        }
    }
}
