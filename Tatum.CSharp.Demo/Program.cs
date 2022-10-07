using Tatum.CSharp.Ethereum.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use your ApiKey from Tatum Dashboard (main/test)
var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");

builder.Services
    .AddHttpClient<IEthereumClient, EthereumClient>(httpClient =>
    {
        var ethereumClient = new EthereumClient(httpClient, apiKey, true);
        return ethereumClient;
    });

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