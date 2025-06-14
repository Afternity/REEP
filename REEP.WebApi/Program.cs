using Microsoft.AspNetCore.Authentication.JwtBearer;
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

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7218/";
        options.Audience = "REEP-WebAPI";
        options.RequireHttpsMetadata = false;
    });

var app = builder.Build();

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
