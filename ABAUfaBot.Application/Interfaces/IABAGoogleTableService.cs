using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IABAGoogleTableService
    {
        Task<IList<IList<Object>>> ReadGoogleSheetAsync(string id, string range);
    }
}
