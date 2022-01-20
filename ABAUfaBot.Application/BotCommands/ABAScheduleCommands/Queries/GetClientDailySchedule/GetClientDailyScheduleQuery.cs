using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetClientSchedule
{
    public class GetClientDailyScheduleQuery : IABABotQuery
    {
        public IABAUser RegisteredUser { get; set; }
        public string Key { get; } = "dayclient";
    }
}
