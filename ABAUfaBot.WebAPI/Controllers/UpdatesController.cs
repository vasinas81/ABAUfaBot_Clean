using System.Threading.Tasks;
using ABAUfaBot.Domain;
using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Application.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetOnknownUserResponse;

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
        private readonly IBotCommandFactory _botCommandFactory;
        private readonly IMediator _mediator;

        public UpdatesController(
            ISendMessageFactory sendMessageFactory,
            IUserABATableProvider userABATableProvider,
            IBotCommandFactory botCommandFactory,
            IMediator mediator)
        {
            _sendMessageFactory = sendMessageFactory;
            _userABATableProvider = userABATableProvider;
            _botCommandFactory = botCommandFactory;
            _mediator = mediator;
        }

        /// <summary>
        /// Take request from telegram bot
        /// </summary>
        /// <param name="updateMessage">JSON with message from bot</param>
        /// <returns>Response message</returns>
        [HttpPost]
        public async Task<SendMessage> PostUpdate(UpdateMessage updateMessage)
        {
            var msg = _sendMessageFactory.Create(updateMessage);
            IABAUser incomingUser = await _userABATableProvider.ReadByNameAsync(updateMessage.message.from.username);

            var botCommand = _botCommandFactory.Create(updateMessage, incomingUser);

            msg.text = await _mediator.Send(botCommand);

            return msg;
        }
    }
}
