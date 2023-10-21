

using AnalisisProyecto.Models.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json");
var configuration = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"];

builder.Services.AddDbContext<AnalisisProyectoContext>(options =>
    options.UseSqlServer(configuration));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
