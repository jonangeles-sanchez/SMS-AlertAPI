using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using SMS_AlertAPI.Service;
using Twilio.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IShoeRequestService, ShoeRequestService>();
builder.Services.AddHttpClient<ITwilioRestClient, TwilioService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = new AmazonDynamoDBConfig
{
    RegionEndpoint = RegionEndpoint.USEast1
};
var credentials = new BasicAWSCredentials("AKIASHQLGZ6QPMP3QFNM", "5jZ7pm2n1W6XHKNUyasOa1xitx+IgjiDDiRhY/GZ");
var client = new AmazonDynamoDBClient(credentials, config);
builder.Services.AddSingleton<IAmazonDynamoDB>(client);
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
