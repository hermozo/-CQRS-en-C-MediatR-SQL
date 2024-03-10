using API.MediatR.Marca.Handlers;
using API1.Domain.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
string conx = builder.Configuration.GetConnectionString("DefaultConnectionString");
var assembly = AppDomain.CurrentDomain.Load("API.MediatR");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(conx);
});
builder.Services.AddMediatR(assembly);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
