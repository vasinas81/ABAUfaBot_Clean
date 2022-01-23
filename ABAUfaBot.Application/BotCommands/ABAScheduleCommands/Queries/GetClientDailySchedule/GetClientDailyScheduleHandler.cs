using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.BotCommands.ABAUserCommands.Queries.GetClientDailySchedule
{
    public class GetClientDailyScheduleHandler :
        IRequestHandler<GetClientDailyScheduleQuery, string>
    {
        private readonly IScheduleABATableProvider _scheduleABATableProvider;
        private readonly IUserABATableProvider _userABATableProvider;
        private readonly IABATableRangeProvider _ABATableRangeProvider;

        public GetClientDailyScheduleHandler(
            IScheduleABATableProvider scheduleABATableProvider,
            IUserABATableProvider userABATableProvider,
            IABATableRangeProvider ABATableRangeProvider)
        {
            _scheduleABATableProvider = scheduleABATableProvider;
            _userABATableProvider = userABATableProvider;
            _ABATableRangeProvider = ABATableRangeProvider;
        }

        public async Task<string> Handle(GetClientDailyScheduleQuery request, CancellationToken cancellationToken)
        {
            var dailyRange = _ABATableRangeProvider.GetDailyScheduleRange(request.ScheduleDay);

            var mentorsList = await _userABATableProvider.ReadByRoleAsync(UserRoles.mentor);
            StringBuilder scheduleSummator = new StringBuilder();

            foreach (IABAUser mentor in mentorsList)
            try
            {
                var mentorScheduleRecords = await _scheduleABATableProvider.ReadScheduleAsync(
                    mentor.TableId,
                    dailyRange);
                var clientInMentorSchedule = mentorScheduleRecords.Where(schedule => request.RegisteredUser.ChildNames.Contains(schedule.ChildName));
                    if (clientInMentorSchedule != null)
                        if (clientInMentorSchedule.Any())
                        {
                            scheduleSummator.Append(string.Format("<b>{0}</b>:\n", mentor.Name));
                            foreach (IABAScheduleRecord scheduleRecord in clientInMentorSchedule)
                            {
                                scheduleSummator.Append(string.Format("{1} : {0} \n", scheduleRecord.ChildName, scheduleRecord.TimeField));
                            }
                        }
            }
            catch { }

            string scheduleStrings = string.Empty;
            
            if (scheduleSummator.Length > 0)
            {
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
