using BCP.Framework.Log;
using CROSS.DATABASE;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using WepApplicationBarberShop.Models.Mapper;
using WepApplicationBarberShop.Repositories;
using WepApplicationBarberShop.Repositories.IRepositories;
using WepApplicationBarberShop.Services.Service;

var MyAllowSpecificOrigins = "_allowOriginChatCenter";
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
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IBarberRepository, BarberRepository>(provider =>
{
    var accesor = provider.GetRequiredService<IHttpContextAccessor>();
    var request = accesor.HttpContext.Request;
    //var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    var env = provider.GetRequiredService<IWebHostEnvironment>();
    //var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/", env.ApplicationName);
    var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), request.PathBase.ToUriComponent());
    var dataAccess = provider.GetRequiredService<IManagerDataBase>();
    return new BarberRepository(dataAccess, absoluteUri + "/Files/");
});


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(new[] { "http://localhost:5173/", "http://localhost:5173", "http://localhost:7285", "http://localhost:4200", "https://devben01", "https://cerben01", "https://btbben01" })
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .SetIsOriginAllowed((Host) => true)
                                .AllowCredentials()
                                .WithExposedHeaders("*");
        });
});
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
app.UseCors(MyAllowSpecificOrigins);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(app.Configuration["dataFileServerConfiguration:pathAttachments"] ?? string.Empty),
    RequestPath = "/Files"
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();