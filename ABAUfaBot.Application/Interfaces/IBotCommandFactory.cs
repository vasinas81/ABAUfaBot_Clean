using ABAUfaBot.Application.Models;
using ABAUfaBot.Domain;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IBotCommandFactory
    {
        Task<string> Execute(UpdateMessage updateMessage, IABAUser registeredUser);
    }
}
