
using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Models;

namespace ABAUfaBot.Application.Factories
{
    public class ReplyDataFactory :
            IReplyDataFactory
    {
        public IReplyData Create(
            UpdateMessage updateData)
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
