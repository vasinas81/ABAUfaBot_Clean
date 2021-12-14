namespace ABAUfaBot.Application.Models
{
    public class SendMessage :
        ResponseMethod
    {
        public bool disable_web_page_preview { get; set; } = false;

        public string parse_mode { get; set; } = string.Empty;

        public string text { get; set; }

        public int chat_id { get; set; }

        public int reply_to_message_id { get; set; }

        public SendMessage() : base("sendMessage")
        {
        }
    }
}
