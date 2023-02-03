using Backend.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using RoyalEstateBackend.Context;
using RoyalEstateBackend.Implementations.Repositories;
using RoyalEstateBackend.Implementations.Service;
using RoyalEstateBackend.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(cors => cors.AddPolicy("RoyalPolicy", policy => {
    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
}));
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IPropertyTypeService, PropertyTypeService>();
string connectionString = builder.Configuration.GetConnectionString("RoyalEstateConnection");
builder.Services.AddDbContext<ApplicationContext>(x => x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("RoyalPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
