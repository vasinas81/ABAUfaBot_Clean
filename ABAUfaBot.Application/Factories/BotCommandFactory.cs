using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.BotCommands;
using ABBAUfaTBot.Application.Interfaces;
using ABBAUfaTBot.Application.Models;
using System.Text.RegularExpressions;

namespace ABBAUfaTBot.Application.Factories
{
    public class BotCommandFactory : IBotCommandFactory
    {
        private readonly Regex CommandRegex = new Regex(@"^\/(?<command>[^\s_]+)([\s_]+(?<parameter>[^\s_]+))*$");
        private readonly IPerson _personInChat;

        public BotCommandFactory(IPerson personInChat)
        {
            _personInChat = personInChat;
        }

        public IBotCommand GetCommand(UpdateMessage updateMessage)
        {
            var match = CommandRegex.Match(updateMessage.message.text);
            IBotCommand botCommand;

            if (!_personInChat.isAuthorized)
            {
                botCommand = new UnknownUserCommand(_personInChat);
            }
            else
            {
                if (!match.Success)
                {
                    botCommand = new UnknownRequestCommand(_personInChat);
                }
                else
                {
                    switch (match.Groups["command"].Value)
                    {
                        case "day":
                            botCommand = new GetScheduleCommand(_personInChat, _tableDataProvider);
                            break;
                        default:
                            botCommand = new DefaultCommand(_personInChat);
                            break;
                    }
                }
            }
            return botCommand;
        }
    }
}
