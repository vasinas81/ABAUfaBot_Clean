using ABAUfaBot.Domain;
using MediatR;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetOnknownRequestResponse
{
    public class GetUnknownRequestResponse : IRequest<string>
    {
        public IABAUser RegisteredUser { get; set; }
    }
}
