using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Services.SqlDatabaseContextService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // ignore reference loop
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
var sqlConnection = builder.Configuration["ConnectionStrings:HotelWeb:SqlDb"];
builder.Services.AddSqlServer<ApplicationDbContext>(sqlConnection, options => options.EnableRetryOnFailure());

builder.Services.AddScoped<IRoomManagementContextService, SqlDatabaseRoomRepository>();

builder.Services.AddScoped<IHotelManagementContextService, SqlDatabaseHotelRepository>();

builder.Services.AddScoped<IApplicationFacilityContextService, SqlDatabaseApplicationFacilityRepository>();
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
