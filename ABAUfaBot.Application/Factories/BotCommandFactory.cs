using ABAUfaBot.Domain;
using ABAUfaBot.Application.BotCommands;
using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Models;
using System.Text.RegularExpressions;

namespace ABAUfaBot.Application.Factories
{
    public class BotCommandFactory : IBotCommandFactory
    {
        private readonly Regex CommandRegex = new Regex(@"^\/(?<command>[^\s_]+)([\s_]+(?<parameter>[^\s_]+))*$");
        private readonly IABAUser _personInChat;

        public BotCommandFactory(IABAUser personInChat)
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
                            //botCommand = new GetScheduleCommand(_personInChat, _tableDataProvider);
                            botCommand = new DefaultCommand(_personInChat);
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
