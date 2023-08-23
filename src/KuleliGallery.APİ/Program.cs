using FluentValidation;
using Kuleli.Shop.Persistence.Context;
using Kuleli.Shop.Application.AutoMappings;
using Kuleli.Shop.Application.Repostories;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Application.Services.Implementation;
using Kuleli.Shop.Application.Validators.Categories;
using Kuleli.Shop.Domain.Service.Abstraction;
using Kuleli.Shop.Domain.Service.Implementation;
using Kuleli.Shop.Domain.UWork;
using Kuleli.Shop.Persistance.Repositories;
using Kuleli.Shop.Persistance.UWork;
using KuleliGallery.AP�.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Logging
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

Log.Logger.Information("Program Started...");

// Add services to the container.

//ActionFilter registiration
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ExceptionHandlerFilter());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtTokenWithIdentity", Version = "v1", Description = "JwtTokenWithIdentity test app" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
});

builder.Services.AddHttpContextAccessor();

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
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILoggedUserService, LoggedUserService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailsService>();

//Automapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(ViewModelToDomain));

//FluentValidation �stekte g�nderilen modele ait property'lerin istenen format� destekleyip desteklemedi�ini anlamam�z� sa�lar.
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCategoryValidator));


// JWT kimlik do�rulama servisini ekleme
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Token� olu�turan taraf�n adresi
            ValidAudience = builder.Configuration["Jwt:Audiance"], // Token�n kullan�laca�� hedef adres
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"])) // Gizli anahtar
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//Kal�c� olarak saklanacak dosyalar i�in kay�t yeri ayarlan�yor.
app.UseStaticFiles();

app.Run();
