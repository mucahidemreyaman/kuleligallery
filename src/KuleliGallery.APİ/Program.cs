using FluentValidation;
using Kuleli.Shop.Application.AutoMappings;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Application.Services.Implementation;
using Kuleli.Shop.Application.Validators.Categories;
using Kuleli.Shop.Persistance.Context;
using KuleliGallery.APÝ.Filters;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ExceptionHandlerFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KuleliGalleryContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("KuleliConnection"));
});
//Business Service Registiration
builder.Services.AddScoped<ICategoryServices, CategoryService>();

//Automapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(ViewModelToDomain));

//FluentValidation istekte gonderilen modele ait propertylerin istenen formatta destekleyip desteklemediðini anlamamýzý saðlar.
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCategoryValidator));

Log.Logger = new LoggerConfiguration()
    .WriteTo.Seq("http://localhost:5341")
    .MinimumLevel.Information()
    .CreateLogger();

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
