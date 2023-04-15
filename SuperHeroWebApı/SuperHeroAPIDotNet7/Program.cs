global using SuperHeroAPIDotNet7.Models;
global using SuperHeroAPIDotNet7.Data;
using SuperHeroAPIDotNet7.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Service
//Bu kod, .NET Core uygulamas�nda dependency injection (ba��ml�l�k enjeksiyonu) kullanarak bir aray�z� veya soyut s�n�f�,
// ilgili bir somut s�n�f uygulamas�yla e�le�tirmek i�in kullan�l�r.

//Bu �rnekte, ISuperHeroService aray�z�, SuperHeroService somut s�n�f�yla e�le�tirilir. Bu, uygulama genelinde ISuperHeroService aray�z�n�
//kullanarak SuperHeroService s�n�f�na eri�mek istedi�imizde,ba��ml�l�k enjeksiyonu taraf�ndan SuperHeroService �rne�inin olu�turulaca��
//ve bizim taraf�m�zdan kullan�labilece�i anlam�na gelir.
//AddScoped metodu, her istek i�in ayr� bir ISuperHeroService �rne�i olu�turulmas�n� sa�lar. Bu �rne�in �mr�,
//HTTP iste�i ile s�n�rl�d�r. Yani, istek sonland���nda �rne�in �mr� sona erer ve bellekten otomatik olarak temizlenir.
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddDbContext<DataContext>();

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
