using ABBAUfaTBot.Application.Models;

namespace ABBAUfaTBot.Application.Interfaces
{
    public interface ISendMessageFactory :
        IFactory<UpdateMessage, SendMessage>
    {
    }
}
