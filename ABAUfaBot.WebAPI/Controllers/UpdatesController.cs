using System.Threading.Tasks;
using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.Factories;
using ABBAUfaTBot.Application.Interfaces;
using ABBAUfaTBot.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABBAUfaTBot.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase
    {
        private readonly ISendMessageFactory _sendMessageFactory;

        public UpdatesController(
            ISendMessageFactory sendMessageFactory)
        {
            _sendMessageFactory = sendMessageFactory;
        }

        [HttpPost]
        public async Task<SendMessage> PostUpdate(UpdateMessage updateMessage)
        {
            var msg = _sendMessageFactory.Create(updateMessage);

            //ABAUserAuthorizer userAuthorizer = new(_tableDataProvider);
            IPerson personInChat = await userAuthorizer.GetAuthorizerUserByAccountAsync(updateMessage.message.from.username);

            var commandFactory = new BotCommandFactory(personInChat);
            msg.text = await commandFactory.GetCommand(updateMessage).RunAsync();
            return msg;
        }

    }
}
