using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Twilio.Clients;
using Twilio.Http;

namespace SMS_AlertAPI.Service
{
    public class TwilioService : ITwilioRestClient
    {
        private readonly ITwilioRestClient _client;
        public TwilioService(IConfiguration config, System.Net.Http.HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("X-Custom-Header", "TwilioRestClient");
            var accountSid = config["Twilio:AccountSid"];
            var authToken = config["Twilio:AuthToken"];
            _client = new TwilioRestClient(accountSid, authToken);
        }

        public Response Request (Request request)
        {
            return _client.Request(request);
        }

        public Task<Response> RequestAsync(Request request)
        {
            return _client.RequestAsync(request);
        }

        public string AccountSid => _client.AccountSid;

        public string Region => _client.Region;

        public Twilio.Http.HttpClient HttpClient => _client.HttpClient;
    }
}
