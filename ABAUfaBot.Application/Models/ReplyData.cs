using ABBAUfaTBot.Application.Interfaces;

namespace ABBAUfaTBot.Application.Models
{
    internal class ReplyData :
        IReplyData
    {
        public int ChatId { get; set; }

        public int MessageId { get; set; }

        public int SenderId { get; set; }

        public string SenderName { get; set; }

        public ReplyData()
        { }
    }
}
