using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetMentorSchedule
{
    public class GetMentorDailyScheduleQuery : IABABotQuery
    {
        public IABAUser RegisteredUser { get; set; }
        public string Key { get; } = "daymentor";
    }
}
