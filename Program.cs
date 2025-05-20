using Microsoft.EntityFrameworkCore;
using Nina.Restoran.Api.Domain;
using Nina.Restoran.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITableRepository, DatabaseTableRepository>();
builder.Services.AddScoped<IPeopleRepository, DatabasePeopleRepository>();
builder.Services.AddScoped<IReservationRepository, DatabaseReservationRepository>();
builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer("Server=DESKTOP-L79TERM;Database=Restaurant;TrustServerCertificate=True;Integrated Security=True;"));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
