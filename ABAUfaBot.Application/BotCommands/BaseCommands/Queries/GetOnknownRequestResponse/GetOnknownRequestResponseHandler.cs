using ABAUfaBot.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetOnknownRequestResponse
{
    public class GetOnknownRequestResponseHandler :
        IRequestHandler<GetUnknownRequestResponse, string>
    {
        public GetOnknownRequestResponseHandler()
        {

        }

        public async Task<string> Handle(GetUnknownRequestResponse request, CancellationToken cancellationToken)
        {
            return string.Format("The request cannot be recognized, User account - {0}", request.RegisteredUser.Account);
        }
    }
}
