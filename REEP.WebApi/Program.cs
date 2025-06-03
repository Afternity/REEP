using REEP.Application;
using REEP.Application.Common.Mappings;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Persistence.DependencyInjections;
using REEP.WebApi.Middleware;
using System.ComponentModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IReepDbContext).Assembly));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
builder.Logging.AddConsole();
builder.Services.AddApplication();
builder.Services.AddDatabaseServices(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
