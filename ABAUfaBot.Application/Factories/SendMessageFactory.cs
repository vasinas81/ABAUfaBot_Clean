using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Models;

namespace ABAUfaBot.Application.Factories
{
    public class SendMessageFactory :
        ISendMessageFactory
    {
        public SendMessage Create(
            UpdateMessage botData)
        {
            return new SendMessage
            {
                chat_id = (botData.message.chat != null) ? botData.message.chat.id : 0,
                parse_mode = "html"
            };
        }
    }
}
