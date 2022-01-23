using ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetClientDailySchedule;
using ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetMentorDailySchedule;
using ABAUfaBot.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ABAUfaBot.Application.BotCommands
{
    public static class RegisterCommandServices
    {
        public static IServiceCollection AddABABotCommandsServices(this IServiceCollection services)
        {
            services.AddTransient<IABABotQuery, GetMentorDailyScheduleQuery>();
            services.AddTransient<IABABotQuery, GetClientDailyScheduleQuery>();

            return services;
        }
    }
}
