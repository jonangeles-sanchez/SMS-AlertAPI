using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS_AlertAPI.Models;
using SMS_AlertAPI.DTOs;
using SMS_AlertAPI.Service;

namespace SMS_AlertAPI.Controllers
{
    [Route("api/v1/alert")]
    [ApiController]
    public class ShoeRequestController : ControllerBase
    {

        private readonly IShoeRequestService _shoeRequestService;
        public ShoeRequestController(IShoeRequestService shoeRequestService)
        {
            _shoeRequestService = shoeRequestService;
        }

        [HttpPost("new")]
        public async Task<ActionResult<List<ShoeRequest>>> CreateRequest(ShoeRequestDto req)
        {
            Console.WriteLine(req);
            ShoeRequest newShoeRequest = new ShoeRequest(
                req.PhoneNumber,
                req.Reminded
            );

            List<Shoe> shoes = new List<Shoe>();
            foreach (ShoeDTO shoe in req.requestedShoes)
            {
                shoes.Add(new Shoe(
                    shoe.Manufacturer,
                    shoe.Name,
                    shoe.Size,
                    shoe.Quantity
                ));
            }

            newShoeRequest.requestedShoes = shoes;

            List<ShoeRequest> shoeRequests = await _shoeRequestService.CreateRequest(newShoeRequest);

            //return Ok(shoeRequests);
            return Ok();

        }

        [HttpGet]
        public async Task<ActionResult<List<ShoeRequest>>> GetRequests()
        {
            return await _shoeRequestService.GetRequests();
        }

        [HttpDelete]
        public async Task DeleteRequests()
        {
            await _shoeRequestService.DeleteRequests();
        }

        [HttpDelete("{PhoneNumber}")]
        public async Task<ActionResult<List<ShoeRequest>>> DeleteRequest(string PhoneNumber)
        {
            return await _shoeRequestService.DeleteRequest(PhoneNumber);
        }
    }
}
