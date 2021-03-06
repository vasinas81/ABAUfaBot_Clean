using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using System;
using System.Linq;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetMentorDailySchedule
{
    public class GetMentorDailyScheduleQuery : IABABotQuery
    {
        public IABAUser RegisteredUser { get; set; }
        public string Key { get; } = "daymentor";

        public DateTime ScheduleDay { get; set; } = DateTime.Now;

        public bool SetAdditionalParameters(params string[] addParams) 
        {
            bool res = true;

            if (addParams != null)
            {
                if (addParams.Length > 0)
                {
                    int day = 0;
                    res = int.TryParse(addParams.First(), out day);
                    if (res)
                        res &= ((day > 0) && (day <= DateTime.DaysInMonth(ScheduleDay.Year, ScheduleDay.Month)));
                    if (res)
                        ScheduleDay = ScheduleDay.AddDays(day - ScheduleDay.Day);
                }
            }
            
            return res;
        }
    }
}
