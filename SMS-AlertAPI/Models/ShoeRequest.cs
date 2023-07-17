using System.ComponentModel.DataAnnotations;

namespace SMS_AlertAPI.Models
{
    public class ShoeRequest
    {
        public int Id { get; set; }

        [Required]
        private int PhoneNumber { get; set; }

        public List<Shoe> requestedShoes { get; set; }

        public ShoeRequest()
        {
        }

        public ShoeRequest(int Id, int PhoneNumber, List<Shoe> requestedShoes)
        {
            this.Id = Id;
            this.PhoneNumber = PhoneNumber;
            this.requestedShoes = requestedShoes;
        }

        public ShoeRequest(int PhoneNumber, List<Shoe> requestedShoes)
        {
            this.PhoneNumber = PhoneNumber;
            this.requestedShoes = requestedShoes;
        }

        public ShoeRequest(int PhoneNumber)
        {
            this.PhoneNumber =(int)PhoneNumber;
        }

    }
}
