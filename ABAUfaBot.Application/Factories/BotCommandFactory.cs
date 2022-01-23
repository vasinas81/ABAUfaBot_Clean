using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Models;
using System.Text.RegularExpressions;
using MediatR;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetDefaultResponse;
using ABAUfaBot.Domain;
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

            string commandKey = string.Empty;
            string[] parameters = null;

            if (!registeredUser.isAuthorized)
            { 
                commandKey = "unknownuser"; 
            }
            else
            if (!match.Success)
            {
                commandKey = "unknownresponse";
            }
            else
            {
                commandKey = match.Groups["command"].Value + registeredUser.Role.ToString();
                parameters = match.Groups["parameter"].Captures.Select(s => s.Value).ToArray();
            }

            IABABotQuery ABABotQuery = _services.FirstOrDefault(o => o.Key.Equals(commandKey)); ;
            if (ABABotQuery == null)
            {
                ABABotQuery = new GetDefaultResponse();
            }
            ABABotQuery.RegisteredUser = registeredUser;
            ABABotQuery.SetAdditionalParameters(parameters);

            return await _mediator.Send(ABABotQuery);
        }
    }
}
