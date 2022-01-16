using ABAUfaBot.Domain;
using MediatR;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetClientSchedule
{
    public class GetClientDailyScheduleQuery : IRequest<string>
    {
        public IABAUser RegisteredUser { get; set; }
    }
}
