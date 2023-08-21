using FluentValidation;
using Kuleli.Shop.Application.AutoMappings;
using Kuleli.Shop.Application.Repostories;
using Kuleli.Shop.Application.Services.Absraction.AccountService;
using Kuleli.Shop.Application.Services.Absraction.CategoryService;
using Kuleli.Shop.Application.Services.Absraction.CityService;
using Kuleli.Shop.Application.Services.Absraction.OrderDetailService;
using Kuleli.Shop.Application.Services.Absraction.OrderService;
using Kuleli.Shop.Application.Services.Absraction.ProductImageService;
using Kuleli.Shop.Application.Services.Absraction.ProductService;
using Kuleli.Shop.Application.Services.Implementation.AccountService;
using Kuleli.Shop.Application.Services.Implementation.CategoryService;
using Kuleli.Shop.Application.Services.Implementation.CityService;
using Kuleli.Shop.Application.Services.Implementation.Order;
using Kuleli.Shop.Application.Services.Implementation.OrderDetail;
using Kuleli.Shop.Application.Services.Implementation.Product;
using Kuleli.Shop.Application.Services.Implementation.ProductImage;
using Kuleli.Shop.Application.Validators.Categories;
using Kuleli.Shop.Domain.Service.Abstraction;
using Kuleli.Shop.Domain.Service.Implementation;
using Kuleli.Shop.Domain.UWork;
using Kuleli.Shop.Persistance.Context;
using Kuleli.Shop.Persistance.Repositories;
using Kuleli.Shop.Persistance.UWork;
using KuleliGallery.APÝ.Filters;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//logging
var configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
       .Build();

Log.Logger = new LoggerConfiguration()
      .ReadFrom.Configuration(configuration)
      .CreateLogger();

Log.Logger.Information("PROGRAM STARTED...");
// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ExceptionHandlerFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext Registiration
builder.Services.AddDbContext<KuleliGalleryContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("KuleliConnection"));
});

//Repository Registiraction
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//UnitOfWork Registiration
builder.Services.AddScoped<IUnitwork, UnitWork>();

//Business Service Registiration
builder.Services.AddScoped<ICategoryServices, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILoggedUserService, LoggedUserService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();


//typeof seklinde de yazabilirdik ama 
//generic olmayan ifadeler icin bu kullaným daha dogrudur..


//Automapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(ViewModelToDomain));

//FluentValidation istekte gonderilen modele ait propertylerin istenen formatta destekleyip desteklemediðini anlamamýzý saðlar.
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCategoryValidator));



var app = builder.Build(); //Dependency Injectiona Unit of worku kurmadýgýmýz icin "https://prnt.sc/PFu1tEhN31Y7" hata alýrýz //

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
