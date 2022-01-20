using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Models;
using System.Text.RegularExpressions;
using MediatR;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetUnknownRequestResponse;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetDefaultResponse;
using ABAUfaBot.Domain;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetUnknownUserResponse;
using ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetMentorSchedule;
using ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetClientSchedule;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.Factories
{
    public class BotCommandFactory : IBotCommandFactory
    {
        private readonly Regex CommandRegex = new Regex(@"^\/(?<command>[^\s_]+)([\s_]+(?<parameter>[^\s_]+))*$");

        private readonly List<IABABotQuery> _services;
        private readonly IMediator _mediator;

        public BotCommandFactory(
            IEnumerable<IABABotQuery> services,
            IMediator mediator)
        {
            _services = services.ToList();
            _mediator = mediator;
        }

        public async Task<string> Execute(UpdateMessage updateMessage, IABAUser registeredUser)
        {
            var match = CommandRegex.Match(updateMessage.message.text);

            IABABotQuery botCommand;
            string commandKey = string.Empty;

            if (!registeredUser.isAuthorized)
            { 
                commandKey = "unknownuser"; 
            }
            else
            if (!match.Success)
            {
                botCommand = new GetUnknownRequestResponse { RegisteredUser = registeredUser };
                commandKey = "unknownresponse";
            }
            else
            {
                commandKey = match.Groups["command"].Value + registeredUser.Role.ToString();
                switch (match.Groups["command"].Value)
                {
                    case "day":
                        if (registeredUser.Role == UserRoles.client)
                        {
                            botCommand = new GetClientDailyScheduleQuery { RegisteredUser = registeredUser };
                        }
                        else
                        {
                            botCommand = new GetMentorDailyScheduleQuery { RegisteredUser = registeredUser };
                        }
                        break;
                    default:
                        botCommand = new GetDefaultResponse { RegisteredUser = registeredUser };
                        break;
                }
            }

            IABABotQuery ABABotQuery = _services.FirstOrDefault(o => o.Key.Equals(commandKey)); ;
            if (ABABotQuery == null)
            {
                ABABotQuery = new GetDefaultResponse();
            }
            ABABotQuery.RegisteredUser = registeredUser;

            return await _mediator.Send(ABABotQuery);
        }
    }
}
