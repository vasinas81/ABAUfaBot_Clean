using ABAUfaBot.Application.Models;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IBotCommandFactory
    {
        IBotCommand GetCommand(UpdateMessage updateMessage);

        //IBotCommand CreateDefault();
    }
}
