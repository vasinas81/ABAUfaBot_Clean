using System.Collections.Generic;
using System.Threading.Tasks;
using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.Interfaces;

namespace ABBAUfaTBot.Application.BotCommands
{
    public class UnknownUserCommand : IBotCommand
    {
        private string AdminAccount { get; } = "@VasinAS_81";

        public string Name { get; } = "UnknownUser";
        public IReadOnlyCollection<string> Parameters { get; }

        private readonly IPerson _personInChat;

        public UnknownUserCommand(IPerson personInChat)
        {
            _personInChat = personInChat;
        }

        private string Run()
        {
            return string.Format("Unknown user {0}, please, write message to {1}, he will add you", 
                _personInChat.Account,
                AdminAccount
                );
        }

        public async Task<string> RunAsync()
        {
            return await Task.Run(() => Run());
        }
    }

}
