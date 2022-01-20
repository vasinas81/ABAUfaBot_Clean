using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetUnknownUserResponse
{
    public class GetUnknownUserResponseQuery : IABABotQuery
    {
        public IABAUser RegisteredUser { get; set; }
        public string Key { get; } = "unknownuser";
    }
}
