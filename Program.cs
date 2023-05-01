using Microsoft.EntityFrameworkCore;
using PTSEventsApi.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PTSEventsApiContext>(opt =>
    opt.UseInMemoryDatabase("PTSEvents"));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PTSEventsContext>(opt =>
    opt.UseInMemoryDatabase("PTSEventsList"));
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
