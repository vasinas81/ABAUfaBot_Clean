using ABAGoogleDocs.Models;
using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using ABAUfaBot.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABAUfaBot.Infrastructure.ABATableProviders
{
    public class SheduleABATableProvider : IScheduleABATableProvider
    {
        public ABAGoogleTableService _currentABAGoogleTableService { get; }

        public SheduleABATableProvider(ABAGoogleTableService currentABAGoogleTableService)
        {
            _currentABAGoogleTableService = currentABAGoogleTableService;
        }

        public async Task<List<IABAScheduleRecord>> ReadDailyAsync(string spreadsheetId)
        {
            string range = GetScheduleRange();
            var rowsList = await _currentABAGoogleTableService.ReadGoogleSheetAsync(spreadsheetId, range);

            return ConvertToRecordsList(rowsList);
        }

        public Task<List<IABAScheduleRecord>> ReadWeeklyAsync(string spreadsheetId)
        {
            throw new NotImplementedException();
        }

        public Task<List<IABAScheduleRecord>> ReadMonthlyAsync(string spreadsheetId)
        {
            throw new NotImplementedException();
        }


        #region private methods
        private List<IABAScheduleRecord> ConvertToRecordsList(IList<IList<Object>> tableRows)
        {
            if (tableRows == null) throw new ArgumentNullException("tableRows", "tableRows is null");

            List<IABAScheduleRecord> scheduleRecords = new List<IABAScheduleRecord>();

            foreach (var row in tableRows)
            {
                if (row.Count > 0)
                    if (row[0].ToString() != string.Empty)
                    {
                        scheduleRecords.Add(new ABAScheduleRecord()
                        {
                            ChildName = row[0].ToString(),
                            TimeField = (row.Count > 2) ? row[2].ToString() : "Time N/A"
                        }); ;
                    }
            }
            return scheduleRecords;
        }

        private string GetScheduleRange()
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
        #endregion
    }
}
