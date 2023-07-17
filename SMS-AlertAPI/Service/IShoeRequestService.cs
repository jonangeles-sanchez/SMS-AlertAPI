using SMS_AlertAPI.DTOs;
using SMS_AlertAPI.Models;

namespace SMS_AlertAPI.Service
{
    public interface IShoeRequestService
    {
        Task<List<ShoeRequest>> CreateRequest(ShoeRequest SRequest);
    }
}
