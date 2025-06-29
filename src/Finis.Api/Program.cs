using System;
using Finis.Application.Interfaces;
using Finis.Application.Services;
using Finis.Infra.Data.Context;
using Finis.Infra.Data.Interfaces;
using Finis.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore; ;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("ApiConnection");

builder.Services.AddDbContext<ApiContext>(Options => {
                      Options.UseSqlServer(connectionString, dbOpts => dbOpts.MigrationsAssembly(typeof(Program).Assembly.FullName));
                   });
builder.Services.AddScoped<ITipoAtivo, TipoAtivoRepository>();      
builder.Services.AddScoped<ITipoAtivoService, TipoAtivoService>();  

builder.Services.AddCors(
    options => {
        options.AddPolicy("cors",builder => {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers().AllowAnonymous();;

app.Run();
