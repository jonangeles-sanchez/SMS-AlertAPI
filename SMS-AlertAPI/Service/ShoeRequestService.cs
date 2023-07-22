using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
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
            // If the phone number already exists, concatenate the new shoes to the existing shoes
            var request = await _dynamoDb.LoadAsync<ShoeRequest>(SRequest.PhoneNumber);
            if(request != null)
            {
                request.requestedShoes.AddRange(SRequest.requestedShoes);
                await _dynamoDb.SaveAsync(request);
                return await _dynamoDb.ScanAsync<ShoeRequest>(new List<ScanCondition>()).GetRemainingAsync();
            }
            await _dynamoDb.SaveAsync(SRequest);
            return await _dynamoDb.ScanAsync<ShoeRequest>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task<List<ShoeRequest>> GetRequests()
        {
            return await _dynamoDb.ScanAsync<ShoeRequest>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task DeleteRequests()
        {
            const string tableName = "ShoeRequests";

            var scanResult = await _dynamoDb.ScanAsync<ShoeRequest>(new List<ScanCondition>()).GetRemainingAsync();

            if(scanResult.Count == 0)
            {
                return;
            }

            foreach (var item in scanResult)
            {
                await _dynamoDb.DeleteAsync<ShoeRequest>(item.PhoneNumber);
            }

        }

        public async Task<List<ShoeRequest>> DeleteRequest(string PhoneNumber)
        {
            var request = await _dynamoDb.LoadAsync<ShoeRequest>(PhoneNumber);
            await _dynamoDb.DeleteAsync(request);
            return await _dynamoDb.ScanAsync<ShoeRequest>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task SetReminded(string PhoneNumber)
        {
            var request = await _dynamoDb.LoadAsync<ShoeRequest>(PhoneNumber);
            request.Reminded = true;
            await _dynamoDb.SaveAsync(request);

        }
    }

}
