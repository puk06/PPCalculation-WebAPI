var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(3007); // �z�X�g���̃|�[�g
});

// �T�[�r�X�o�^
builder.Services.AddControllers();

var app = builder.Build();

// ���[�e�B���O�ݒ�
app.MapControllers();

app.Run();