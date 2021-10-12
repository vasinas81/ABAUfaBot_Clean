using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.BotCommands;
using ABBAUfaTBot.Application.Interfaces;

namespace ABBAUfaTBot.Application.Factories
{
    public class UnknownUserBotCommandFactory : IBotCommandFactory
    {
        private readonly IPerson _personInChat;

        public UnknownUserBotCommandFactory(IPerson personInChat)
        {
            _personInChat = personInChat;
        }

        public IBotCommand Create()
        {
            return new UnknownUserCommand(_personInChat);
        }
    }
}
