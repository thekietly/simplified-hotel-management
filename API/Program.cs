using Infrastructure.Persistent;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.SqlDatabaseContextService;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // ignore reference loop
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.SetIsOriginAllowed(origin =>
        {
            // Add URL/Ports that are allowed to access the API
            var allowedOrigins = new[]
            {
                "http://localhost:3000"
            };

            return allowedOrigins.Contains(origin);
        })
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Add database service
var sqlConnection = builder.Configuration.GetConnectionString("HotelWeb:SqlDb");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(sqlConnection));

// App Services
builder.Services.AddScoped<IRoomManagementContextService, SqlDatabaseRoomRepository>();

builder.Services.AddScoped<IHotelManagementContextService, SqlDatabaseHotelRepository>();

builder.Services.AddScoped<IApplicationFacilityContextService, SqlDatabaseApplicationFacilityRepository>();
builder.Services.AddLogging();

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapIdentityApi<IdentityUser>();
app.UseCors("AllowReactApp");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
