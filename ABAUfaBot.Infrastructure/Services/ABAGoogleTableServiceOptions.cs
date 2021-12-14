using ABAUfaBot.Application.Interfaces;

namespace ABAUfaBot.Infrastructure.Services
{
    public class ABAGoogleTableServiceOptions : IABAGoogleTableServiceOptions
    {
        public string ServiceActEmail { get; set; }
        public string ServiceAppName { get; set; }
        public string PrivateKey { get; set; }
    }
}
