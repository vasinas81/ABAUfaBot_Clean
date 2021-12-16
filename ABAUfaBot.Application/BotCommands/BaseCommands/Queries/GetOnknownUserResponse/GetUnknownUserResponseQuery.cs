using ABAUfaBot.Domain;
using MediatR;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetOnknownUserResponse
{
    public class GetUnknownUserResponseQuery : IRequest<string>
    {
        public IABAUser RegisteredUser { get; set; }
    }
}
