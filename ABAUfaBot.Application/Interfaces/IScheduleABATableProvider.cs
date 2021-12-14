using ABAUfaBot.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IScheduleABATableProvider
    {
        Task<List<IABAScheduleRecord>> ReadDailyAsync(string spreadsheetId);
        Task<List<IABAScheduleRecord>> ReadWeeklyAsync(string spreadsheetId);
        Task<List<IABAScheduleRecord>> ReadMonthlyAsync(string spreadsheetId);
    }
}
