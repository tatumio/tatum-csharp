using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Extensions.ServiceCollection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();