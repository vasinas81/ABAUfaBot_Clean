using ABAUfaBot.Application.Models;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IReplyDataFactory :
        IFactory<UpdateMessage, IReplyData>
    {
    }
}
