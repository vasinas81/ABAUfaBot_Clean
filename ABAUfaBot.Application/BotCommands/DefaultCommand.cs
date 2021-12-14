using System.Collections.Generic;
using System.Threading.Tasks;
using ABAUfaBot.Domain;
using ABAUfaBot.Application.Interfaces;

namespace ABAUfaBot.Application.BotCommands
{
    public class DefaultCommand : IBotCommand
    {
        public string Name { get; } = "Default";
        public IReadOnlyCollection<string> Parameters { get; }

        private readonly IABAUser _personInChat;

        public DefaultCommand(IABAUser personInChat)
        {
            _personInChat = personInChat;
        }

        private string Run()
        {
            return string.Format("Welcome, {0}", _personInChat.Name);
        }

        public async Task<string> RunAsync()
        {
            return await Task.Run(() => Run());
        }
    }
}
