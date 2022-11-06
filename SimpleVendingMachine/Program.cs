

using Microsoft.EntityFrameworkCore;
using SimpleVendingMachine.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductContext>(opt =>
    opt.UseInMemoryDatabase("Product"));
builder.Services.AddDbContext<InvoiceContext>(opt =>
    opt.UseInMemoryDatabase("Invoice"));
builder.Services.AddDbContext<InvoiceItemContext>(opt =>
    opt.UseInMemoryDatabase("InvoiceItem"));

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
