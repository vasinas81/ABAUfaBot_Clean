using ABAUfaBot.Domain;

namespace ABAGoogleDocs.Models
{
    public class ABAScheduleRecord : IABAScheduleRecord
    {
        public string ChildName { get; set; }
        public string TimeField { get; set; }

        public ABAScheduleRecord()
        { }
    }
}
