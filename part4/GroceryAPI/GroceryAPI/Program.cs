using AutoMapper;
using Grocery.Core.Repositories;
using Grocery.Core.Service;
using Grocery.Data;
using Grocery.Data.Repositories;
using Grocery.Service;
using GroceryAPI.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

//מניעה לולאה אינסופית בגלל הספק במחלקת מוצר
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
        policy.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(@"Server=DESKTOP-SSNMLFD;DataBase=GroceryDb;TrustServerCertificate=True;Trusted_Connection=True"));

builder.Services.AddScoped<IGrocerService, GrocerService>();
builder.Services.AddScoped<IGrocerRepository, GrocerRepository>();
builder.Services.AddAutoMapper(typeof(PostMappingGrocer), typeof(PostMappingGrocerLogin));


builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddAutoMapper(typeof(PostMappingSupplier), typeof(PostMappingSupplierLogin));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(PostMappingProduct));

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddAutoMapper(typeof(PostMappingOrder));

var app = builder.Build();
app.UseCors("AllowLocalhost");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();


app.Run();
