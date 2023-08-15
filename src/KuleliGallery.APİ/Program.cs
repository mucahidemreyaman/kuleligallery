using FluentValidation;
using Kuleli.Shop.Application.AutoMappings;
using Kuleli.Shop.Application.Repostories;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Application.Services.Implementation;
using Kuleli.Shop.Application.Validators.Categories;
using Kuleli.Shop.Persistance.Context;
using Kuleli.Shop.Persistance.Repositories;
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

//Repository Registiration
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//Business Service Registiration
builder.Services.AddScoped<ICategoryServices, CategoryService>();//typeof seklinde de yazabilirdik ama 
//generic olmayan ifadeler icin bu kullaným daha dogrudur..


//Automapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(ViewModelToDomain));

//FluentValidation istekte gonderilen modele ait propertylerin istenen formatta destekleyip desteklemediðini anlamamýzý saðlar.
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCategoryValidator));


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
