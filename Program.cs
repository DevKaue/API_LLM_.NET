using API_LLM.Data;
using API_LLM.Entities.Car;
using API_LLM.Services.Carros;
using API_LLM.Services.Interfaces.Carros;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Services
builder.Services.AddScoped<ICarrosInterface, CarroService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

//SEED DB
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();

    if (!db.Carros.Any())
    {
        db.Carros.AddRange(
            new Carro { Marca = "Toyota", Modelo = "Corolla", Valor = 120000 },
            new Carro { Marca = "Toyota", Modelo = "Hilux", Valor = 250000 },
            new Carro { Marca = "Honda", Modelo = "Civic", Valor = 130000 }
        );
        db.SaveChanges();
    }
}




// Configuração de ambiente de desenvolvimento
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("Development", builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//    });
//});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware para desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseCors("Development");
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
