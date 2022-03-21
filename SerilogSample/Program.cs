using Serilog;
using SerilogSample.Configurations;


LoggingConfig.ConfigureLogging();
var builder = WebApplication.CreateBuilder(args);



builder.Host.ConfigureAppConfiguration(config =>
{
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    config.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true);
});

builder.Host.ConfigureLogging(Host =>
{
    Host.ClearProviders(); // Net Core içerisince custom bir logger var.
});

builder.Host.UseSerilog(); // serilog paketini kullanacaðým.


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






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
