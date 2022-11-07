using Microsoft.EntityFrameworkCore;
using SimpleVendingMachine.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProductContext>(opt =>
    opt.UseInMemoryDatabase("Products"));
builder.Services.AddDbContext<InvoiceContext>(opt =>
    opt.UseInMemoryDatabase("Invoice"));
builder.Services.AddDbContext<InvoiceItemContext>(opt =>
    opt.UseInMemoryDatabase("InvoiceItem"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
