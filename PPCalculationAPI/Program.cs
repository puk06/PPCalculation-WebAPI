var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(3008);
});

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
