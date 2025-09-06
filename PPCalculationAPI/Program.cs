var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(3007); // ホスト側のポート
});

// サービス登録
builder.Services.AddControllers();

var app = builder.Build();

// ルーティング設定
app.MapControllers();

app.Run();