using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.Factories;
using ABBAUfaTBot.Application.Interfaces;
using System.Text.RegularExpressions;

namespace ABBAUfaTBot.Application.BotCommands
{
    public class CommandProccessor
    {
        private static readonly Regex CommandRegex = new Regex(@"^\/(?<command>[^\s_]+)([\s_]+(?<parameter>[^\s_]+))*$");

        public static IBotCommand UnPackCommand(Update updateMessage, IPerson personInChat, IABATableProvider tableDataProvider)
        {
            IBotCommandFactory botCommandFactory;

            var match = CommandRegex.Match(updateMessage.message.text);

            if (!personInChat.isAuthorized)
            {
                botCommandFactory = new UnknownUserBotCommandFactory(personInChat);
            }
            else
            {
                if (!match.Success)
                {
                    botCommandFactory = new UnknownRequestBotCommandFactory(personInChat);
                }
                else
                {
                    switch (match.Groups["command"].Value)
                    {
                        case "day":
                            botCommandFactory = new GetScheduleBotCommandFactory(personInChat, tableDataProvider);
                            break;
                        default:
                            botCommandFactory = new DefaultBotCommandFactory(personInChat);
                            break;
                    }
                }
            }

            return botCommandFactory.Create();
        }
    }
}
