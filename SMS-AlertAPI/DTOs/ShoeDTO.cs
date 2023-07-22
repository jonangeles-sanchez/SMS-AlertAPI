using System.ComponentModel.DataAnnotations;

namespace SMS_AlertAPI.DTOs
{
    public class ShoeDTO
    {
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Size { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
