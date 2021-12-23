using ABAGoogleDocs.Models;
using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using ABAUfaBot.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAUfaBot.Infrastructure.ABATableProviders
{
    public class SheduleABATableProvider : IScheduleABATableProvider
    {
        public IABAGoogleTableService _currentABAGoogleTableService { get; }

        public SheduleABATableProvider(IABAGoogleTableService currentABAGoogleTableService)
        {
            _currentABAGoogleTableService = currentABAGoogleTableService;
        }

        public async Task<List<IABAScheduleRecord>> ReadScheduleAsync(string spreadsheetId, string range)
        {
            var rowsList = await _currentABAGoogleTableService.ReadGoogleSheetAsync(spreadsheetId, range);

            return ConvertToRecordsList(rowsList);
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
        #endregion
    }
}
