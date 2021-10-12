
using ABBAUfaTBot.Application.Interfaces;
using ABBAUfaTBot.Application.Models;

namespace ABBAUfaTBot.Application.Factories
{
    public class ReplyDataFactory :
            IReplyDataFactory
    {
        public IReplyData Create(
            Update updateData)
        {
            return new ReplyData
            {
                ChatId = updateData.message.chat.id,
                MessageId = updateData.message.message_id,
                SenderId = updateData.message.from.id,
                SenderName = updateData.message.from.first_name,
            };
        }
    }
}
