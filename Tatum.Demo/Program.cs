using Newtonsoft.Json.Converters;
using Tatum.Core.Models;
using Tatum.Extensions.ServiceCollection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddControllers()
    .AddNewtonsoftJson(opts =>
{
    opts.SerializerSettings.Converters.Add(new StringEnumConverter());
});
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();


// ************** Tatum SDK **************

var apiKey = Environment.GetEnvironmentVariable("NOTIFICATION_TEST_APIKEY");

builder.Services.AddTatumSdkWithDebug(Network.Testnet, apiKey);

// ************** /Tatum SDK **************



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();