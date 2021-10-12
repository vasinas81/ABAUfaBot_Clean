
using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.BotCommands;
using ABBAUfaTBot.Application.Interfaces;

namespace ABBAUfaTBot.Application.Factories
{
    public class UnknownRequestBotCommandFactory : IBotCommandFactory
    {
        private readonly IPerson _personInChat;

        public UnknownRequestBotCommandFactory(IPerson personInChat)
        {
            _personInChat = personInChat;
        }

        public IBotCommand Create()
        {
            return new UnknownRequestCommand(_personInChat);
        }
    }
}
