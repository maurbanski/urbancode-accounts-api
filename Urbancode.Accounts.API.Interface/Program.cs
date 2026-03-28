using NLog;
using NLog.Extensions.Logging;
using Urbancode.Accounts.API.Interface;
using LogLevel = NLog.LogLevel;

var builder = WebApplication.CreateBuilder(args);

//Set up logging
var logger = LogManager.Setup().LoadConfigurationFromSection(builder.Configuration).GetCurrentClassLogger();
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug);
builder.Logging.AddNLog();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

try
{
    builder.AddInfrastructureServices();
    builder.AddApplicationServices();
    
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // app.UseHttpsRedirection();

    app.MapControllers();
    logger.Log(NLog.LogLevel.Info, "API started");

    app.Run();
}
catch (Exception ex)
{
    logger.Log(NLog.LogLevel.Fatal, ex);
    throw;
}
