using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Clients;
using SMS_AlertAPI.DTOs;
using Twilio.Rest.Api.V2010.Account;

namespace SMS_AlertAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class TwilioController : ControllerBase
    {
        private readonly ITwilioRestClient _client;
        public TwilioController(ITwilioRestClient client)
        {
            _client = client;
        }

        [HttpPost("PhoneNumber")]
        public IActionResult SendSms(SmsMessageDTO req)
        {
            var message = MessageResource.Create(
                body: req.Body,
                from: new Twilio.Types.PhoneNumber(req.From),
                to: new Twilio.Types.PhoneNumber(req.To),
                client: _client);
            return Ok("The following message was sent succesfully: \n" + message.Body);
        }
    }
}
