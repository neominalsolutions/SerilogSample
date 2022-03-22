using Serilog;
using SerilogSample.Configurations;
using SerilogSample.Middlewares;
using SerilogSample.Services;

LoggingConfig.ConfigureLogging();
var builder = WebApplication.CreateBuilder(args);



builder.Host.ConfigureAppConfiguration(config =>
{
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    config.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true);
}).ConfigureLogging(Host =>
{
    Host.ClearProviders(); // Net Core içerisince custom bir logger var.
}).UseSerilog(); // serilog paketini kullanacaðým.


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<WeatherForecastService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLogContextMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
