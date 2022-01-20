using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using MediatR;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetUnknownRequestResponse
{
    public class GetUnknownRequestResponse : IABABotQuery
    {
        public IABAUser RegisteredUser { get; set; }
        public string Key { get; } = "unknownresponse";
    }
}
