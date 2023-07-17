using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SMS_AlertAPI.Models
{
    public class Shoe
    {
        public int Id { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Size { get; set; }

        [JsonIgnore]
        public ShoeRequest Request { get; set; }
    }
}
