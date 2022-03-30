using System.Reflection;
using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore.Design;
using PipelineBehavior;

using FluentValidation;
using ContosoPizza.Context;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connection);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Retornator
builder.Services.AddControllers().AddRetornator();

builder.Services.AddErrorTranslator(ErrorHttpTranslatorBuilder.Default);

//MediatR DI
builder.Services.AddMediatR(Assembly.GetEntryAssembly()) 
.AddFluentValidation();

////PipelineBehavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

//Validators
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

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
