using Domain;
using Repository;
using Services;



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
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
