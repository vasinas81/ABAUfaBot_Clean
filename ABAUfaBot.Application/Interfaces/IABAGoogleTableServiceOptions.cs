using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IABAGoogleTableServiceOptions
    {
        string ServiceActEmail { get; set; }
        string ServiceAppName { get; set; }
        string PrivateKey { get; set; }
    }
}
