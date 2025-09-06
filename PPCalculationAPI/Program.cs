var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(3008); // ホスト側のポート
});

// サービス登録
builder.Services.AddControllers();

var app = builder.Build();

// ルーティング設定
app.MapControllers();

app.Run();
