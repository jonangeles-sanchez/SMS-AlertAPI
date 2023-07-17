using System.ComponentModel.DataAnnotations;

namespace SMS_AlertAPI.Models
{
    public class ShoeRequest
    {
        public int Id { get; set; }

        [Required]
        private int PhoneNumber { get; set; }

        public List<Shoe> requestedShoes { get; set; }

    }
}
