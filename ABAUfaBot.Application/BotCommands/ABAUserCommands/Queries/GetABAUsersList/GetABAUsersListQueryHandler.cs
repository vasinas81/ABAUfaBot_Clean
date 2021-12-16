using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetABAUsersList
{
    public class GetABAUsersListQueryHandler :
        IRequestHandler<GetABAUsersListQuery, string>
    {
        public GetABAUsersListQueryHandler()
        {

        }

        public async Task<string> Handle(GetABAUsersListQuery request, CancellationToken cancellationToken)
        {
            return string.Format("Welcome, {0}");
        }
    }
}
