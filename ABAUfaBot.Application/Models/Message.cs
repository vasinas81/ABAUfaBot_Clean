using System.Linq;

namespace ABAUfaBot.Application.Models
{
    public class Message
    {
        public long Id { get; set; }
        public long message_id { get; set; }
        public User from { get; set; }
        public Chat chat { get; set; }
        public string text { get; set; }

        public static long GetNewMessageId(Message[] messageList)
        {
            return (messageList.Count() > 0) ? (messageList.ToArray()[messageList.Count() - 1].Id + 1) : 0;
        }
    }
}
