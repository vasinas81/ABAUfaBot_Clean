using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Models;
using System.Text.RegularExpressions;
using MediatR;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetOnknownRequestResponse;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetDefaultResponse;
using ABAUfaBot.Domain;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetOnknownUserResponse;
using ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetMentorSchedule;

namespace ABAUfaBot.Application.Factories
{
    public class BotCommandFactory : IBotCommandFactory
    {
        private readonly Regex CommandRegex = new Regex(@"^\/(?<command>[^\s_]+)([\s_]+(?<parameter>[^\s_]+))*$");

        public BotCommandFactory()
        {

        }

        public IRequest<string> Create(UpdateMessage updateMessage, IABAUser registeredUser)
        {
            var match = CommandRegex.Match(updateMessage.message.text);
            IRequest<string> botCommand;

            if (!registeredUser.isAuthorized)
                return new GetUnknownUserResponseQuery
                {
                    RegisteredUser = registeredUser
                };

            if (!match.Success)
            {
                botCommand = new GetUnknownRequestResponse
                {
                    RegisteredUser = registeredUser
                };
            }
            else
            {
                switch (match.Groups["command"].Value)
                {
                    case "day":
                        botCommand = new GetMentorDailyScheduleQuery
                        {
                            RegisteredUser = registeredUser
                        };
                        break;
                    default:
                        botCommand = new GetDefaultResponse
                        {
                            RegisteredUser = registeredUser
                        };
                        break;
                }
            }
            return botCommand;
        }
    }
}
