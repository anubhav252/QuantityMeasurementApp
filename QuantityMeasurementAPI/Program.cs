using Microsoft.EntityFrameworkCore;
using QuantityMeasurementData.Interfaces;
using QuantityMeasurementData;
using QuantityMeasurementServices.Services;
using QuantityMeasurementServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuantityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IQuantityRepository, QuantityRepository>();
builder.Services.AddScoped<IQuantityMeasurementService, QuantityMeasurementService>();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();