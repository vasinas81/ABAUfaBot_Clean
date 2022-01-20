using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetUnknownRequestResponse
{
    public class GetUnknownRequestResponseHandler :
        IRequestHandler<GetUnknownRequestResponse, string>
    {
        public GetUnknownRequestResponseHandler()
        {

        }

        public async Task<string> Handle(GetUnknownRequestResponse request, CancellationToken cancellationToken)
        {
            return string.Format("The request cannot be recognized, User account - {0}", request.RegisteredUser.Account);
        }
    }
}
