using Microsoft.EntityFrameworkCore;
using PTSEventsApi.Data;
using Microsoft.Extensions.DependencyInjection;
using PTSEventsApi.Data.Repositories;
using PTSEventsApi.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<PTSEventsContext>(opt =>
    opt.UseInMemoryDatabase("PTSEvents"));

// Add services to the container.

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

//Cors - Allow calling from web browser
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.Run();
