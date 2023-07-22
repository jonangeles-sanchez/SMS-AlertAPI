using System.ComponentModel.DataAnnotations;

namespace SMS_AlertAPI.DTOs
{
    public class ShoeRequestDto
    {
        [Required]
        public String PhoneNumber { get; set; }
        public List<ShoeDTO> requestedShoes { get; set; }
        public Boolean Reminded { get; set; }
    }
}
