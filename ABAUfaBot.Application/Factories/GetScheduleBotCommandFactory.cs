using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.BotCommands;
using ABBAUfaTBot.Application.Interfaces;

namespace ABBAUfaTBot.Application.Factories
{
    public class GetScheduleBotCommandFactory : IBotCommandFactory
    {
        private readonly IPerson _personInChat;
        private readonly IABATableProvider _tableDataProvider;

        public GetScheduleBotCommandFactory(IPerson personInChat, IABATableProvider tableDataProvider)
        {
            _personInChat = personInChat;
            _tableDataProvider = tableDataProvider;
        }

        public IBotCommand Create()
        {
            return new GetScheduleCommand(_personInChat, _tableDataProvider);
        }
    }
}
