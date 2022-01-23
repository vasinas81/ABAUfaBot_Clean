using ABAUfaBot.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.BotCommands.BaseCommands.Queries.GetUnknownUserResponse
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
            return string.Format("Неизвестный пользователь {0}, напишите, пожалуйста {1} для добавления нового пользователя",
                request.RegisteredUser.Account,
                _adminOptions.AdminEmail
                );
        }
    }
}
