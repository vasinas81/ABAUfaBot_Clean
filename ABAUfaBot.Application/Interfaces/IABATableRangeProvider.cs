using System;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IABATableRangeProvider
    {
        string GetDailyScheduleRange(DateTime currentDate);
    }
}
