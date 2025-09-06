var builder = WebApplication.CreateBuilder(args);

// サービス登録
builder.Services.AddControllers();

var app = builder.Build();

// ルーティング設定
app.MapControllers();

app.Run();