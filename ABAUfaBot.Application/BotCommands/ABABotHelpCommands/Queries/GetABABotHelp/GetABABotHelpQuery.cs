using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using System;
using System.Linq;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetABABotHelp
{
    public class GetABABotHelpQuery : IABABotQuery
    {
        public IABAUser RegisteredUser { get; set; }
        public string Key { get; } = "help";

        public bool SetAdditionalParameters(params string[] addParams)
        {
            return true;
        }
    }
}
