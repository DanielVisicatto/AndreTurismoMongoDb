using AndreTurismoMongoDb.Config;
using AndreTurismoMongoDb.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AndreTurismoMongoSettings>(builder.Configuration.GetSection("AndreTurismoMongoSettings"));
builder.Services.AddSingleton<IAndreTurismoMongoSettings>(s => s.GetRequiredService<IOptions<AndreTurismoMongoSettings>>().Value);
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<AddressService>();
builder.Services.AddSingleton<CityService>();

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
