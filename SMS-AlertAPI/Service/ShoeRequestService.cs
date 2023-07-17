using Amazon.DynamoDBv2.DataModel;
using SMS_AlertAPI.Models;

namespace SMS_AlertAPI.Service
{
    public class ShoeRequestService : IShoeRequestService
    {
        IDynamoDBContext _dynamoDb;
        public ShoeRequestService(IDynamoDBContext dynamoDBContext) 
        { 
            _dynamoDb = dynamoDBContext;
        }

        public async Task<List<ShoeRequest>> CreateRequest(ShoeRequest SRequest)
        {
            await _dynamoDb.SaveAsync(SRequest);
            return await _dynamoDb.ScanAsync<ShoeRequest>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task<List<ShoeRequest>> GetRequests()
        {
            return await _dynamoDb.ScanAsync<ShoeRequest>(new List<ScanCondition>()).GetRemainingAsync();
        }
    }

}
