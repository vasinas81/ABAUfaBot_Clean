using ABAUfaBot.Application.Models;

namespace ABAUfaBot.Application.Interfaces
{
    public interface ISendMessageFactory :
        IFactory<UpdateMessage, SendMessage>
    {
    }
}
