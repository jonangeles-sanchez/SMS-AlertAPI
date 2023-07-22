using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SMS_AlertAPI.Models
{
    public class Shoe
    {

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Size { get; set; }
        [Required]
        public int Quantity { get; set; }

        [JsonIgnore]
        public ShoeRequest Request { get; set; }

        public Shoe() { }

        public Shoe(string manufacturer, string name, double size, int quantity)
        {
            Manufacturer = manufacturer;
            Name = name;
            Size = size;
            Quantity = quantity;
        }

        public Shoe(string manufacturer, string name, double size, ShoeRequest request)
        {
            Manufacturer = manufacturer;
            Name = name;
            Size = size;
            Request = request;
        }
    }
}
