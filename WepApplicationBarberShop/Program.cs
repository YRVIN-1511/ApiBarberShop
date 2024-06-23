using BCP.Framework.Log;
using CROSS.DATABASE;
using Microsoft.OpenApi.Models;
using WepApplicationBarberShop.Commons.Helpers;
using WepApplicationBarberShop.Models.Mapper;
using WepApplicationBarberShop.Repositories;
using WepApplicationBarberShop.Repositories.IRepositories;
using WepApplicationBarberShop.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Barber - Service",
        Version = "v1",
        Description = "Api Core Sistema de Barberia",
        Contact = new OpenApiContact
        {
            Name = "Yrvin Perez",
            Email = "perez.choque.yrvin@gmail.com"
        }
    });
    //c.OperationFilter<CustomHeaderSwaggerAttribute>();
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" } }, new string[] { } } });
});
builder.Services.AddScoped<IBarberService, BarberService>();
builder.Services.AddDataBase();
builder.Services.AddScoped<IBarberRepository, BarberRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

IConfiguration Configuration = app.Configuration;
string logPathFile = Configuration.GetValue<string>("Logs:PathFile");
string logLevel = Configuration.GetValue<string>("Logs:Level");
int logLimit = Configuration.GetValue<int>("Logs:Limit").Equals(0) ? 30 : Configuration.GetValue<int>("Logs:Limit");
_ = new Logger(logPathFile, logLimit, logLevel);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
var pathBase = "";
app.UseSwagger();
app.UseSwaggerUI(c =>
{
#if DEBUG
    string DGS_OAS3JsonUrl = $"{(!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty)}/swagger/v1/swagger.json";
#else
    string DGS_OAS3JsonUrl = $"{(!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty)}../swagger/v1/swagger.json";
#endif
    c.SwaggerEndpoint(DGS_OAS3JsonUrl, "BARBER - Service");
    c.OAuthAppName("BARBER - Service");
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();