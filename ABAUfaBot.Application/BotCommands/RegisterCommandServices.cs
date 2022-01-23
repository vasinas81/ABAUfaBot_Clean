using ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetClientDailySchedule;
using ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetMentorDailySchedule;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetDefaultResponse;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetUnknownRequestResponse;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetUnknownUserResponse;
using ABAUfaBot.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ABAUfaBot.Application.BotCommands
{
    public static class RegisterCommandServices
    {
        public static IServiceCollection AddABABotCommandsServices(this IServiceCollection services)
        {
            services.AddTransient<IABABotQuery, GetDefaultResponse>();
            services.AddTransient<IABABotQuery, GetUnknownRequestResponse>();
            services.AddTransient<IABABotQuery, GetUnknownUserResponseQuery>();
            services.AddTransient<IABABotQuery, GetMentorDailyScheduleQuery>();
            services.AddTransient<IABABotQuery, GetClientDailyScheduleQuery>();

            return services;
        }
    }
}
