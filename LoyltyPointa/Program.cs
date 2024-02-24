using LoyltyPointa.Repo.GravityService;
using LoyltyPointa.Repo.Service.GravityService;
using LoyltyPointa.RepoImpl.ServiceImpl.GravityServiceImpl;
using Serilog;
using Serilog.Core;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().MinimumLevel.Override("Microsoft",LogEventLevel.Information).WriteTo.Console().CreateLogger();
DotNetEnv.Env.Load();   
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<GravityService,GravityServiceImpl>();
builder.Services.AddSingleton<LoyaltyStoreService,LoyaltyStoreServiceImpl>();
builder.Services.AddAuthentication();
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
