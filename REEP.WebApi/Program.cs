using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using REEP.Application;
using REEP.Application.Common.Mappings;
using REEP.Application.Interfaces.InterfaceDbContexts;
using REEP.Persistence.DependencyInjections;
using REEP.WebApi;
using REEP.WebApi.Middleware;
using Swashbuckle.AspNetCore.SwaggerGen;
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

//builder.Services.AddAuthentication(config =>
//{
//    config.DefaultAuthenticateScheme =
//        JwtBearerDefaults.AuthenticationScheme;
//    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer("Bearer", options =>
//    {
//        options.Authority = "https://localhost:7218/";
//        options.Audience = "REEP-WebAPI";
//        options.RequireHttpsMetadata = false;
//    });
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("x-api-version"),
        new QueryStringApiVersionReader("api-version"));
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
    ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    // Подключение XML-документации (если есть)
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Показывает детали ошибок
}
else
{
    app.UseCustomExceptionHandler(); // Ваш кастомный обработчик
}

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
// app.UseAuthentication();
// app.UseAuthorization();
app.UseApiVersioning();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            $"REEP API {description.GroupName.ToUpper()}");
    }
    options.RoutePrefix = string.Empty; // для того чтоб работал swagger при старте, до этого было options.RoutePrefix = "swagger";
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
