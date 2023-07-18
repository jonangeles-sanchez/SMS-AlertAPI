using System.ComponentModel.DataAnnotations;

namespace SMS_AlertAPI.DTOs
{
    public class SmsMessageDTO
    {
        [Required]
        public string To { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string From { get; set; }
    }
}
