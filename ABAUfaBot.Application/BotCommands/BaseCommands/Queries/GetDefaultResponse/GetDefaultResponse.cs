using ABAUfaBot.Domain;
using MediatR;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetDefaultResponse
{
    public class GetDefaultResponse : IRequest<string>
    {
        public IABAUser RegisteredUser { get; set; }
    }
}
