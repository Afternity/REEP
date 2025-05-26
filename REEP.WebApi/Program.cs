using REEP.Persistence.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseServices(builder.Configuration);

var app = builder.Build();
app.Run();
