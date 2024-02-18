using LoyltyPointa.Repo.GravityService;
using LoyltyPointa.RepoImpl.GravityServiceImpl;
using Serilog;
using Serilog.Core;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().MinimumLevel.Override("Microsoft",LogEventLevel.Information).WriteTo.Console().CreateLogger();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<GravityService,GravityServiceImpl>();
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
