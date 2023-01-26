using Ocelot.DependencyInjection;
using Ocelot.Middleware;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(opt => opt.AddDefaultPolicy(c =>
{
    c.AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin 
        .AllowCredentials();
}));
builder.Services.AddOcelot(configuration);
var app = builder.Build();
app.UseCors();
app.UseOcelot();
app.Run();
