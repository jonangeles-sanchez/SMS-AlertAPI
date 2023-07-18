using SMS_AlertAPI.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Clients;
using SMS_AlertAPI.DTOs;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;
using Twilio.Types;

namespace SMS_AlertAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class TwilioController : ControllerBase
    {
        private readonly ITwilioRestClient _client;
        private readonly string PhoneNumber;
        public TwilioController(ITwilioRestClient client, IConfiguration config)
        {
            _client = client;
            this.PhoneNumber = config["Twilio:PhoneNumber"] ?? "+19895850910";
        }


        [HttpPost("notify/{ToPhoneNumber}/{MessageType}")]
        public IActionResult SendSms(string ToPhoneNumber, string MessageType)
        {
            if( MessageType is null )
            {
                return BadRequest("Please specify a message type.");
            }
            var message = MessageResource.Create(
                body: new MessageBuilder(MessageType).GetMessage(),
                from: new Twilio.Types.PhoneNumber(PhoneNumber),
                to: new Twilio.Types.PhoneNumber(ToPhoneNumber),
                client: _client);
            return Ok("The following message was sent succesfully: \n" + message.Body);
        }

    }
}
