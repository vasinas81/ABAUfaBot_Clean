using System;

namespace ABBAUfaTBot.Application.Models
{
    public class ResponseMethod
    {
        public string method { get; }

        public ResponseMethod(
            string method)
        {
            this.method = method ?? throw new ArgumentNullException(nameof(method));
        }
    }
}
