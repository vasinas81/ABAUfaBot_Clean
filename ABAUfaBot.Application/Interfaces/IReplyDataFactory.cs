using ABBAUfaTBot.Application.Models;

namespace ABBAUfaTBot.Application.Interfaces
{
    public interface IReplyDataFactory :
        IFactory<UpdateMessage, IReplyData>
    {
    }
}
