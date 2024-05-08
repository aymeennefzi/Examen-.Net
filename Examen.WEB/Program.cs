using AM.ApplicationCore.Interfaces;
using AM.Infrastructure;
using Examen.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Services;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<Type>(p=>typeof(GenericRepository<>));
builder.Services.AddDbContext<DbContext, ExamenContext>();


// instanciation des services
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContext,ExamenContext>(); // connexion base de donnée
builder.Services.AddScoped<IBanqueService, BanqueService>(); //instanciation service
builder.Services.AddScoped<ICompteService, CompteService>(); //instanciation service

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // instanciation les pattron de conception
builder.Services.AddScoped<Type>(p => typeof(GenericRepository<>)); //instanciation repo


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
