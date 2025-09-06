using Microsoft.EntityFrameworkCore;
using Minimal_API.Infraestrutura.Db;

using MinimalAPI.DTOs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DbContexto>(options =>
{
    options.UseMySql(
            builder.Configuration.GetConnectionString("mysql"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))

     );
});



var app = builder.Build();

app.MapPost("/login", (MinimalAPI.DTOs.LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login com sucesso");
    else
        return Results.Unauthorized();
    {

    }
});

app.Run();





