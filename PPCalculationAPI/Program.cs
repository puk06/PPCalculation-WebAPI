var builder = WebApplication.CreateBuilder(args);

// �T�[�r�X�o�^
builder.Services.AddControllers();

var app = builder.Build();

// ���[�e�B���O�ݒ�
app.MapControllers();

app.Run();