using ABAUfaBot.Application.Interfaces;
using System;

namespace ABAUfaBot.Application.Common.RangeProviders
{
    public class ABATableRangeProvider : IABATableRangeProvider
    {
        public string GetDailyScheduleRange(DateTime currentDate)
        {
            string[] namesColumns = { "B", "E", "H", "K", "N" };
            string[] timeColumns = { "D", "G", "J", "M", "P" };

            var firstDayOfTheMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            var numberDayOfWeek = Convert.ToInt16(firstDayOfTheMonth.DayOfWeek.ToString("D").Replace('0', '7'));
            int numberWeekOfTheMonth = (currentDate.Day + numberDayOfWeek) / 7;

            var currentDayOfWeek = Convert.ToInt16(currentDate.DayOfWeek.ToString("D").Replace('0', '7'));
            string month = (currentDate.Month < 10) ? ("0" + currentDate.Month.ToString()) : (currentDate.Month.ToString());
            int startRow = 3 + (currentDayOfWeek - 1) * 14;
            int endRow = startRow + 13;
            string range = string.Format("{4}.{5}!{0}{2}:{1}{3}",
                namesColumns[numberWeekOfTheMonth],
                timeColumns[numberWeekOfTheMonth],
                startRow.ToString(),
                endRow.ToString(),
                month,
                currentDate.Year.ToString()
                );
            return range;
        }
    }
}
