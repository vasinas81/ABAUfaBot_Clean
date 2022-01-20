using ABAUfaBot.Domain;
using MediatR;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IABABotQuery : IRequest<string>
    {
        IABAUser RegisteredUser { get; set; }
        string Key { get; }
    }
}
