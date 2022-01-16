using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetMentorSchedule
{
    public class GetMentorDailyScheduleHandler :
        IRequestHandler<GetMentorDailyScheduleQuery, string>
    {
        private readonly IScheduleABATableProvider _scheduleABATableProvider;
        private readonly IABATableRangeProvider _ABATableRangeProvider;

        public GetMentorDailyScheduleHandler(
            IScheduleABATableProvider scheduleABATableProvider,
            IABATableRangeProvider ABATableRangeProvider)
        {
            _scheduleABATableProvider = scheduleABATableProvider;
            _ABATableRangeProvider = ABATableRangeProvider;
        }

        public async Task<string> Handle(GetMentorDailyScheduleQuery request, CancellationToken cancellationToken)
        {
            var dailyRange = _ABATableRangeProvider.GetDailyScheduleRange(DateTime.Today);

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
            StringBuilder scheduleSummator = new StringBuilder();
            if (scheduleRecords.Count != 0)
            {
                foreach (IABAScheduleRecord scheduleRecord in scheduleRecords)
                {
                    scheduleSummator.Append(string.Format("{1} : {0} \n", scheduleRecord.ChildName, scheduleRecord.TimeField));
                }
                scheduleStrings = scheduleSummator.ToString();
            }
            else
            {
                scheduleStrings = $"На указанный период занятий не найдено!";
            }

            return scheduleStrings;
        }
    }
}
