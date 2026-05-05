using Infra.Config;
using Infra.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.OpenApi;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PesquisaContext>(options =>             //Novo Swagger                  
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEfRepositories();                              //Novo Swagger


// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>                                   //Novo Swagger
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
    });


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Swagger                                                      //Novo Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>                             //Novo Swagger
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pesquisa API",
        Version = "v1",
        Description = "API do projeto Pesquisa"

    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pesquisa API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
