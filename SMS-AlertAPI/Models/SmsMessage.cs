namespace SMS_AlertAPI.Models
{
    public class SmsMessage
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string From { get; set; }

        public SmsMessage(string to, string body, string from)
        {
            To = to;
            Body = body;
            From = from;
        }
    }
}
