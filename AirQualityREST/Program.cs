using AirQualityREST.Luftkvalitet;
using Luftkvalitet;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                              policy =>
                              {
                                  policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                              });
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add a singleton service
//builder.Services.AddSingleton<MeasurementRepo>();
var optionsBuilder = new DbContextOptionsBuilder<MeasurmentDbContext>();
optionsBuilder.UseSqlServer(Secrets.ConnectionString);

MeasurmentDbContext _dbContext = new(optionsBuilder.Options);
builder.Services.AddSingleton<MeasurmentsRepoDB>(new MeasurmentsRepoDB(_dbContext));

var app = builder.Build();

//CORS
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run(); 
