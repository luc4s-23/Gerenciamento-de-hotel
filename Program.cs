using Hoteis.API.Data;
using Hoteis.API.Repository;
using Hoteis.API.Service;
using Microsoft.EntityFrameworkCore; // <-- ADICIONAR ESTE USING

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IHospedeRepository, HospedeRepository>();
//builder.Services.AddScoped<IHospedeService, HospedeService>();

builder.Services.AddScoped<IQuartoService, QuartoService>();
builder.Services.AddScoped<IQuartoRepository, QuartoRepository>();

// builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
// builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IReservaService, ReservaService>();

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