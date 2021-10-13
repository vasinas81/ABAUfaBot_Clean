using ABBAUfaTBot.Application.Models;

namespace ABBAUfaTBot.Application.Interfaces
{
    public interface IBotCommandFactory
    {
        IBotCommand GetCommand(UpdateMessage updateMessage);

        //IBotCommand CreateDefault();
    }
}
