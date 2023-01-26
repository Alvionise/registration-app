using DomainService.Dal;
using DomainService.WebApi.Extensions;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.RegisterEntityFramework<AppDbContext>(connectionString);
builder.Services.RegisterRepositories();
builder.Services.RegisterAutomapperProfiles();

builder.Services.AddMediatR(typeof(Program));

builder.Services.RegisterValidation();

var app = builder.Build();

DatabaseServiceExtension<AppDbContext>.PrepareDbAndSeed(app.Services);

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}
