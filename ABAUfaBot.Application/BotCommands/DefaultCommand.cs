using System.Collections.Generic;
using System.Threading.Tasks;
using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.Interfaces;

namespace ABBAUfaTBot.Application.BotCommands
{
    public class DefaultCommand : IBotCommand
    {
        public string Name { get; } = "Default";
        public IReadOnlyCollection<string> Parameters { get; }

        private readonly IPerson _personInChat;

        public DefaultCommand(IPerson personInChat)
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
