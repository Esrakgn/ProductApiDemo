using ProductApiDemo.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using ProductApiDemo.Repositories;
using ProductApiDemo.Repositories.Context;
using ProductApiDemo.Repositories.Contracts;
using ProductApiDemo.Services;
using ProductApiDemo.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
//veritabanı bağlantısı için gerekli konfigürasyonu yapıyoruz.


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductManager>();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
