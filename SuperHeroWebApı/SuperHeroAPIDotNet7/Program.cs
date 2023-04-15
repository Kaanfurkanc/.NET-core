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
//Bu kod, .NET Core uygulamasýnda dependency injection (baðýmlýlýk enjeksiyonu) kullanarak bir arayüzü veya soyut sýnýfý,
// ilgili bir somut sýnýf uygulamasýyla eþleþtirmek için kullanýlýr.

//Bu örnekte, ISuperHeroService arayüzü, SuperHeroService somut sýnýfýyla eþleþtirilir. Bu, uygulama genelinde ISuperHeroService arayüzünü
//kullanarak SuperHeroService sýnýfýna eriþmek istediðimizde,baðýmlýlýk enjeksiyonu tarafýndan SuperHeroService örneðinin oluþturulacaðý
//ve bizim tarafýmýzdan kullanýlabileceði anlamýna gelir.
//AddScoped metodu, her istek için ayrý bir ISuperHeroService örneði oluþturulmasýný saðlar. Bu örneðin ömrü,
//HTTP isteði ile sýnýrlýdýr. Yani, istek sonlandýðýnda örneðin ömrü sona erer ve bellekten otomatik olarak temizlenir.
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
