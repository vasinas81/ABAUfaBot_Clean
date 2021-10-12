using ABBAUfaTBot.Application.Interfaces;
using ABBAUfaTBot.Application.Models;

namespace ABBAUfaTBot.Application.Factories
{
    public class SendMessageFactory :
        ISendMessageFactory
    {
        public SendMessage Create(
            Update botData)
        {
            return new SendMessage
            {
                chat_id = (botData.message.chat != null) ? botData.message.chat.id : 0,
                reply_to_message_id = botData.message.message_id,
            };
        }
    }
}
