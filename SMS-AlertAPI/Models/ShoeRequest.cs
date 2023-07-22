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
        public Boolean Reminded { get; set; }

        public ShoeRequest()
        {
        }

        public ShoeRequest(String PhoneNumber, List<Shoe> requestedShoes, Boolean reminded)
        {
            this.PhoneNumber = PhoneNumber;
            this.requestedShoes = requestedShoes;
            Reminded = reminded;
        }

        public ShoeRequest(String PhoneNumber, Boolean Reminded)
        {
            this.PhoneNumber = PhoneNumber;
            this.Reminded = Reminded;
        }

        public ShoeRequest(String PhoneNumber)
        {
            this.PhoneNumber = PhoneNumber;
        }

    }
}
