using Domain;
using Repository;
using Services;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

var constring = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddAutoMapperConfig();
builder.Services.AddBuilder();
builder.Services.AddData(constring);
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
