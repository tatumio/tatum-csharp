using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tatum.CSharp.Bitcoin.Clients;
using Tatum.CSharp.Bsc.Clients;
using Tatum.CSharp.Demo.ExampleServices.Bitcoin;
using Tatum.CSharp.Ethereum.Clients;
using Tatum.CSharp.Harmony.Clients;
using Tatum.CSharp.Polygon.Clients;
using Tatum.CSharp.Utils.DebugMode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use your ApiKey from Tatum Dashboard (main/test)
var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");

builder.Services.AddSingleton<DebugModeHandler>();

builder.Services
    .AddHttpClient<IEthereumClient, EthereumClient>(httpClient => new EthereumClient(httpClient, apiKey))
    .AddHttpMessageHandler<DebugModeHandler>();

builder.Services
    .AddHttpClient<IBitcoinClient, BitcoinClient>(httpClient => new BitcoinClient(httpClient, apiKey));

builder.Services
    .AddHttpClient<IPolygonClient, PolygonClient>(httpClient => new PolygonClient(httpClient, apiKey));

builder.Services
    .AddHttpClient<IBscClient, BscClient>(httpClient => new BscClient(httpClient, apiKey));

builder.Services
    .AddHttpClient<IHarmonyClient, HarmonyClient>(httpClient => new HarmonyClient(httpClient, apiKey));

// Add example services for bitcoin
builder.Services.AddTransient<BlockchainTransferExampleService>();
builder.Services.AddTransient<GenerateWalletExampleService>();
builder.Services.AddTransient<GetBalanceExampleService>();
builder.Services.AddTransient<GenerateAddressExampleService>();
builder.Services.AddTransient<GeneratePrivateKeyExampleService>();
builder.Services.AddTransient<GetTransactionsExampleService>();

// Add example services for ethereum
builder.Services.AddTransient<Tatum.CSharp.Demo.ExampleServices.Ethereum.BlockchainTransferExampleService>();
builder.Services.AddTransient<Tatum.CSharp.Demo.ExampleServices.Ethereum.GenerateAddressExampleService>();
builder.Services.AddTransient<Tatum.CSharp.Demo.ExampleServices.Ethereum.GeneratePrivateKeyExampleService>();
builder.Services.AddTransient<Tatum.CSharp.Demo.ExampleServices.Ethereum.GenerateWalletExampleService>();
builder.Services.AddTransient<Tatum.CSharp.Demo.ExampleServices.Ethereum.GetBalanceExampleService>();
builder.Services.AddTransient<Tatum.CSharp.Demo.ExampleServices.Ethereum.GetTransactionExampleService>();

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