var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(3008);
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Warning);
builder.Logging.AddFilter("CalculateController", level => level >= LogLevel.Information);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();