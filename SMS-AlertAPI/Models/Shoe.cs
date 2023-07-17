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

        public Shoe() { }

        public Shoe (int id, string manufacturer, string name, double size, ShoeRequest request)
        {
            Id = id;
            Manufacturer = manufacturer;
            Name = name;
            Size = size;
            Request = request;
        }

        public Shoe(string manufacturer, string name, double size)
        {
            Manufacturer = manufacturer;
            Name = name;
            Size = size;
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
