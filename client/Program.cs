using Application.Common.Interface;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
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
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Management API");
    });
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
//app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
