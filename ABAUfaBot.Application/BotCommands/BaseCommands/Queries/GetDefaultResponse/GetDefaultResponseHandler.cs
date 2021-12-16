using ABAUfaBot.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetDefaultResponse
{
    public class GetDefaultResponseHandler :
        IRequestHandler<GetDefaultResponse, string>
    {

        public GetDefaultResponseHandler()
        {

        }

        public async Task<string> Handle(GetDefaultResponse request, CancellationToken cancellationToken)
        {
            return string.Format("Welcome, {0}", request.RegisteredUser.Name);
        }
    }
}
