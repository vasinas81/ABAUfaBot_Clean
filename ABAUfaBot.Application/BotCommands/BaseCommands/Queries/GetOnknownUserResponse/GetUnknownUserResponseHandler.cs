using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetOnknownUserResponse
{
    public class GetUnknownUserResponseHandler :
        IRequestHandler<GetUnknownUserResponseQuery, string>
    {
        private readonly IAdminOptions _adminOptions;

        public GetUnknownUserResponseHandler(
            IAdminOptions adminOptions
            )
        {
            _adminOptions = adminOptions;
        }

        public async Task<string> Handle(GetUnknownUserResponseQuery request, CancellationToken cancellationToken)
        {
            return string.Format("Unknown user {0}, please, write message to {1}, he will add you",
                request.RegisteredUser.Account,
                _adminOptions.AdminEmail
                );
        }
    }
}
