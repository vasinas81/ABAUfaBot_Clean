using ABAUfaBot.Domain;
using MediatR;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetMentorSchedule
{
    public class GetMentorDailyScheduleQuery : IRequest<string>
    {
        public IABAUser RegisteredUser { get; set; }
    }
}
