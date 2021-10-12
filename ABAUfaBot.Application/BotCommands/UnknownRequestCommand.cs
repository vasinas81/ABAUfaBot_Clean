using System.Collections.Generic;
using System.Threading.Tasks;
using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.Interfaces;

namespace ABBAUfaTBot.Application.BotCommands
{
    public class UnknownRequestCommand : IBotCommand
    {
        public string Name { get; } = "Default";
        public IReadOnlyCollection<string> Parameters { get; }

        private readonly IPerson _personInChat;

        public UnknownRequestCommand(IPerson personInChat)
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
