using AutoMapper;
using marketplace3.BusinessLogicLayer.Configurations;
using marketplace3.DataAccessLayer;
using marketplace3.DataAccessLayer.Repositories;
using marketplace3.BusinessLogicLayer.Services;
using marketplace3.BusinessLogicLayer.Validation;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using marketplace3.DataAccessLayer.Interfaces;
using Microsoft.OpenApi.Models;
using marketplace3.BusinessLogicLayer.Interfaces.Services;
using marketplace3.DataAccessLayer.Data.Repositories;
using marketplace3.DataAccessLayer.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add DbContext with connection string from appsettings.json
builder.Services.AddDbContext<MarketplaceContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register UnitOfWork and Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();
builder.Services.AddScoped<ISellerServiceCategoryRepository, SellerServiceCategoryRepository>();
builder.Services.AddScoped<IServicePricingRepository, ServicePricingRepository>();

// Register Services
builder.Services.AddScoped<ISellerServiceCategoriesService, SellerServiceCategoriesService>();
builder.Services.AddScoped<ISellersService, SellersService>();
builder.Services.AddScoped<ILocationsService, LocationsService>();
builder.Services.AddScoped<IServicePricingsService, ServicePricingsService>();

// Register FluentValidation validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ServiceCategoryRequestValidator>();

// Configure Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Marketplace API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marketplace API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
