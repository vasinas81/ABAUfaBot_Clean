using ABAUfaBot.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IScheduleABATableProvider
    {
        Task<List<IABAScheduleRecord>> ReadScheduleAsync(string spreadsheetId, string range);
    }
}
