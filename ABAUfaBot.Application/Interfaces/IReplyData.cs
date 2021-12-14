
namespace ABAUfaBot.Application.Interfaces
{
    public interface IReplyData
    {
        int ChatId { get; }
        int MessageId { get; }
        int SenderId { get; }
        string SenderName { get; }
    }
}
