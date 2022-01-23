using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Models;
using System.Text.RegularExpressions;
using MediatR;
using ABAUfaBot.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.Factories
{
    public class BotCommandSelector : IBotCommandSelector
    {
        private readonly Regex CommandRegex = new Regex(@"^\/(?<command>[^\s_]+)([\s_]+(?<parameter>[^\s_]+))*$");

        private readonly List<IABABotQuery> _services;
        private readonly IMediator _mediator;
        private readonly IAdminOptions _adminOptions;

        public BotCommandSelector(
            IEnumerable<IABABotQuery> services,
            IMediator mediator,
            IAdminOptions adminOptions
            )
        {
            _adminOptions = adminOptions;
            _services = services.ToList();
            _mediator = mediator;
        }

        public async Task<string> Execute(UpdateMessage updateMessage, IABAUser registeredUser)
        {
            var match = CommandRegex.Match(updateMessage.message.text);
            string commandAnswer = string.Empty;
            if (!registeredUser.isAuthorized)
            {
                commandAnswer = string.Format("Неизвестный пользователь {0}, напишите, пожалуйста {1} для добавления нового пользователя",
                    registeredUser.Account,
                    _adminOptions.AdminEmail
                );
            }
            else
            if (!match.Success)
            {
                commandAnswer = "Формат команды неизвестен, выберите команду /help для просмотра справки!";
            }
            else
            {
                string commandKey = match.Groups["command"].Value + registeredUser.Role.ToString();
                string[] parameters = match.Groups["parameter"].Captures.Select(s => s.Value).ToArray();
                IABABotQuery ABABotQuery = _services.FirstOrDefault(o => commandKey.Contains(o.Key));
                if (ABABotQuery != null)
                {
                    ABABotQuery.RegisteredUser = registeredUser;
                    if (ABABotQuery.SetAdditionalParameters(parameters))
                    { commandAnswer = await _mediator.Send(ABABotQuery); }
                    else
                    { commandAnswer = "Неправильные параметры команды, выберите команду /help для просмотра справки!"; }
                }
                else
                {
                    string.Format("Привет, {0}!", registeredUser.Name);
                }
            }            

            return commandAnswer;
        }
    }
}
