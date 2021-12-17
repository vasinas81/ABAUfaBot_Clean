using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetMentorSchedule
{
    public class GetMentorDailyScheduleHandler :
        IRequestHandler<GetMentorDailyScheduleQuery, string>
    {
        private readonly IScheduleABATableProvider _scheduleABATableProvider;

        public GetMentorDailyScheduleHandler(IScheduleABATableProvider scheduleABATableProvider)
        {
            _scheduleABATableProvider = scheduleABATableProvider;
        }

        public async Task<string> Handle(GetMentorDailyScheduleQuery request, CancellationToken cancellationToken)
        {
            var dailyRange = GetDailyScheduleRange();
            List<IABAScheduleRecord> scheduleRecords = null;
            try
            {
                scheduleRecords = await _scheduleABATableProvider.ReadScheduleAsync(
                    request.RegisteredUser.TableId,
                    dailyRange);
            }
            catch
            {
                scheduleRecords = new List<IABAScheduleRecord>();
            }

            string scheduleStrings = string.Empty;
            if (scheduleRecords.Count != 0)
            {
                foreach (IABAScheduleRecord scheduleRecord in scheduleRecords)
                {
                    scheduleStrings +=
                        string.Format("{1} : {0} \n", scheduleRecord.ChildName, scheduleRecord.TimeField);
                }
            }
            else
            {
                scheduleStrings = $"На указанный период занятий не найдено!";
            }

            return scheduleStrings;
        }

        private string GetDailyScheduleRange()
        {
            string[] namesColumns = { "B", "E", "H", "K", "N" };
            string[] timeColumns = { "D", "G", "J", "M", "P" };

            DateTime currentDate = DateTime.Now;
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
