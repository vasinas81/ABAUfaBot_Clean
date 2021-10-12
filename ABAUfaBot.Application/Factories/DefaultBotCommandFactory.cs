using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.BotCommands;
using ABBAUfaTBot.Application.Interfaces;

namespace ABBAUfaTBot.Application.Factories
{
    public class DefaultBotCommandFactory : IBotCommandFactory
    {
        private readonly IPerson _personInChat;

        public DefaultBotCommandFactory(IPerson personInChat)
        {
            _personInChat = personInChat;
        }

        public IBotCommand Create()
        {
            return new DefaultCommand(_personInChat);
        }
    }
}
