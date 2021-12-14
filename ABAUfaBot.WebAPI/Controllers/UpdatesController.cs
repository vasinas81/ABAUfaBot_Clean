using System.Threading.Tasks;
using ABAUfaBot.Domain;
using ABAUfaBot.Application.Factories;
using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABAUfaBot.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class UpdatesController : ControllerBase
    {
        private readonly ISendMessageFactory _sendMessageFactory;
        private readonly IUserABATableProvider _userABATableProvider;

        public UpdatesController(
            ISendMessageFactory sendMessageFactory,
            IUserABATableProvider userABATableProvider)
        {
            _sendMessageFactory = sendMessageFactory;
            _userABATableProvider = userABATableProvider;
        }

        /// <summary>
        /// Take request from telegram bot
        /// </summary>
        /// <param name="updateMessage">JSON with message from bot</param>
        /// <returns>Response message</returns>
        [HttpPost]
        public async Task<SendMessage> PostUpdate(UpdateMessage updateMessage)
        {
            IABAUser incomingUser = await _userABATableProvider.ReadByNameAsync(updateMessage.message.from.username);

            var msg = _sendMessageFactory.Create(updateMessage);

            //ABAUserAuthorizer userAuthorizer = new(_tableDataProvider);
            //IABAUser personInChat = await userAuthorizer.GetAuthorizerUserByAccountAsync(updateMessage.message.from.username);

            //var commandFactory = new BotCommandFactory(personInChat);
            //msg.text = await commandFactory.GetCommand(updateMessage).RunAsync();

            return msg;
        }

    }
}
