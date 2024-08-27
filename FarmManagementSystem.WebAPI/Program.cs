using FarmManagementSystem.Domain.Interfaces;
using FarmManagementSystem.Infra.Data;
using FarmManagementSystem.Infra.Repositorios;
using FarmManagementSystem.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var stringConnetion = "DefaultConnection";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IEmployeeRpository, EmployeeRpository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FarmService>();
builder.Services.AddScoped<CropService>();
builder.Services.AddScoped<AnimalService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<LocationService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(stringConnetion));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();