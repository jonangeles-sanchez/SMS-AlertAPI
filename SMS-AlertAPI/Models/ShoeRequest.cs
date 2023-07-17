using System.ComponentModel.DataAnnotations;
using Amazon.DynamoDBv2.DataModel;

namespace SMS_AlertAPI.Models
{
    [DynamoDBTable("ShoeRequests")]
    public class ShoeRequest
    {

        [Required]
        public String PhoneNumber { get; set; }

        public List<Shoe> requestedShoes { get; set; }

        public ShoeRequest()
        {
        }

        public ShoeRequest(int Id, String PhoneNumber, List<Shoe> requestedShoes)
        {
            this.Id = Id;
            this.PhoneNumber = PhoneNumber;
            this.requestedShoes = requestedShoes;
        }

        public ShoeRequest(String PhoneNumber, List<Shoe> requestedShoes)
        {
            this.PhoneNumber = PhoneNumber;
            this.requestedShoes = requestedShoes;
        }

        public ShoeRequest(String PhoneNumber)
        {
            this.PhoneNumber = PhoneNumber;
        }

    }
}
