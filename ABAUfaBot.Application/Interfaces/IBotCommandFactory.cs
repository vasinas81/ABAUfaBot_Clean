using ABAUfaBot.Application.Models;
using ABAUfaBot.Domain;
using MediatR;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IBotCommandFactory
    {
        IRequest<string> Create(UpdateMessage updateMessage, IABAUser registeredUser);
    }
}
