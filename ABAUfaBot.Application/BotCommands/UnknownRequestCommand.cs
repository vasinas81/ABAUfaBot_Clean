using System.Collections.Generic;
using System.Threading.Tasks;
using ABAUfaBot.Domain;
using ABAUfaBot.Application.Interfaces;

namespace ABAUfaBot.Application.BotCommands
{
    public class UnknownRequestCommand : IBotCommand
    {
        public string Name { get; } = "Default";
        public IReadOnlyCollection<string> Parameters { get; }

        private readonly IABAUser _personInChat;

        public UnknownRequestCommand(IABAUser personInChat)
        {
            _personInChat = personInChat;
        }

        private string Run()
        {
            return string.Format("The request cannot be recognized, User account - {0}", _personInChat.Account);
        }

        public async Task<string> RunAsync()
        {
            return await Task.Run(() => Run());
        }
    }
}
