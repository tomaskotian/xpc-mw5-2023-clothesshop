
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Migrations;
using ClothesShop.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

var data = new InitialData();
CorrectManufacturer.GetCorrectManufacturerBogus(data);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<InitialData>();
builder.Services.AddScoped<IClothingRepository,ClothingRepository>();
builder.Services.AddScoped<IShoesRepository, ShoesRepository>();
builder.Services.AddScoped<IAccessoriesRepository, AccessoriesRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
