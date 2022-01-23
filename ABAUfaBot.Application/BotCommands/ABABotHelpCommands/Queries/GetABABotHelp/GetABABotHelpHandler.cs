using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetABABotHelp
{
    public class GetABABotHelpHandler :
        IRequestHandler<GetABABotHelpQuery, string>
    {
        public GetABABotHelpHandler()
        {
        }

        public async Task<string> Handle(GetABABotHelpQuery request, CancellationToken cancellationToken)
        {
            string helpMessage = "Команды бота: \n" +
                "<b>/day</b> - расписание на текущий день \n" +
                "<b>/day xx</b> - расписание на любой день месяца хх \n" +
                "<b>/week</b> - расписание на текущую неделю \n" +
                "<b>/week xx</b> - расписание на любую неделю месяца по дате хх \n";
            return helpMessage;
        }        
    }
}
