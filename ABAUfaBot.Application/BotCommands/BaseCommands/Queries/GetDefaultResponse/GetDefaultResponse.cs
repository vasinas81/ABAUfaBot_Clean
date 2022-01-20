using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetDefaultResponse
{
    public class GetDefaultResponse : IABABotQuery
    {
        public IABAUser RegisteredUser { get; set; }
        public string Key { get; } = "defaultresponse";
    }
}
