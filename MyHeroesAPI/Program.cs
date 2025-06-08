using Microsoft.EntityFrameworkCore;
using MyHeroesAPI.Data;
using MyHeroesAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//foram configuradas as duas formas de banco de dados(In-Memory e SqlServer)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    //options.UseInMemoryDatabase("SuperHeroiDb");
});

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

//para popular banco In-Memory, comentar em caso de uso de um banco real
void SeedDatabase(AppDbContext context)
{
    var superpoderes = new List<Superpoderes>
    {
        new Superpoderes { Id = 1, Superpoder = "Vôo" },
        new Superpoderes { Id = 2, Superpoder = "Super Força" },
        new Superpoderes { Id = 3, Superpoder = "Telepatia" },
        new Superpoderes { Id = 4, Superpoder = "Invisibilidade" },
        new Superpoderes { Id = 5, Superpoder = "Super velocidade" },
        new Superpoderes { Id = 6, Superpoder = "Teletransporte" },
        new Superpoderes { Id = 7, Superpoder = "Regeneração Acelerada" },
        new Superpoderes { Id = 8, Superpoder = "Manipulação de Elementos" },
        new Superpoderes { Id = 9, Superpoder = "Campo de Força" },
        new Superpoderes { Id = 10, Superpoder = "Controle Mental" }
    }   ;

    var herois = new List<Heroi>
    {
        new Heroi
    {
        Id = 1,
        Nome = "Peter Parker",
        NomeHeroi = "Homem-Aranha",
        DataNascimento = new DateTime(1995, 8, 10),
        Altura = 1.78f,
        Peso = 75f,
        HeroisSuperpoderes = new List<HeroisSuperpoderes>
        {
            new HeroisSuperpoderes { HeroiId = 1, SuperpoderId = 5 },
            new HeroisSuperpoderes { HeroiId = 1, SuperpoderId = 7 },
        }
    },
    new Heroi
    {
        Id = 2,
        Nome = "Tony Stark",
        NomeHeroi = "Homem de Ferro",
        DataNascimento = new DateTime(1970, 5, 29),
        Altura = 1.85f,
        Peso = 95f,
        HeroisSuperpoderes = new List<HeroisSuperpoderes>
        {
            new HeroisSuperpoderes { HeroiId = 2, SuperpoderId = 6 }
        }
    },
    new Heroi
    {
        Id = 3,
        Nome = "Clark Kent",
        NomeHeroi = "Superman",
        DataNascimento = new DateTime(1938, 6, 18),
        Altura = 1.91f,
        Peso = 102f,
        HeroisSuperpoderes = new List<HeroisSuperpoderes>
        {
            new HeroisSuperpoderes { HeroiId = 3, SuperpoderId = 1 },
            new HeroisSuperpoderes { HeroiId = 3, SuperpoderId = 2 },
            new HeroisSuperpoderes { HeroiId = 3, SuperpoderId = 5 },
            new HeroisSuperpoderes { HeroiId = 3, SuperpoderId = 9 },
        }
    }
    };

    context.Herois.AddRange(herois);
    context.SaveChanges();
}

// Chama o seed ao iniciar o app, comentar em caso de uso de um banco real
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedDatabase(dbContext);
}

app.Run();
