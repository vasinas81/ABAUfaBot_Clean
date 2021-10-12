using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABAGoogleDocs.Models;
using ABAUfaBot.Domain;
using ABBAUfaTBot.Application.Interfaces;

namespace ABBAUfaTBot.Application.BotCommands
{
    public class GetScheduleCommand : IBotCommand
    {
        public string Name { get; } = "Default";
        public IReadOnlyCollection<string> Parameters { get; }

        private readonly IPerson _personInChat;
        private readonly IABATableProvider _tableDaTableProvider;

        public GetScheduleCommand(IPerson personInChat, IABATableProvider tableDaTableProvider)
        {
            _personInChat = personInChat;
            _tableDaTableProvider = tableDaTableProvider;
        }

        public async Task<string> RunAsync()
        {
            var scheduleReader = new ScheduleReader(_personInChat, _tableDaTableProvider);
            string scheduleStrings = string.Empty;

            var task = scheduleReader.GetSheduleList();

            try
            {
                if (await Task.WhenAny(task, Task.Delay(5000)) == task)
                {
                    var scheduleRecords = task.Result;

                    if (scheduleRecords.Count() != 0)
                    {
                        foreach (ABAScheduleRecord scheduleRecord in scheduleRecords)
                        {
                            scheduleStrings +=
                                string.Format("{1} : {0} \n", scheduleRecord.ChildName, scheduleRecord.TimeField);
                        }
                    }
                    else
                    {
                        scheduleStrings = $"На указанный период занятий не найдено!";
                    }
                }
                else
                {
                    scheduleStrings = $"Гугл долго отвечает, сорри(";
                }
            }
            catch
            {
                scheduleStrings = $"Нераспознанная ошибка при запросе расписания";
            }

            return scheduleStrings;
        }
    }
}
