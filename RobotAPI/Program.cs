using Microsoft.OpenApi.Models;
using System.Reflection;
using RobotAPI.Services;

namespace RobotAPI;

/// <summary>
/// Initial point for the code
/// </summary>
public class Program
{
    /// <summary>
    /// Main method
    /// </summary>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddTransient<RobotService>();
        builder.Services.AddControllers();

        //builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Robot API", Version = "v1" });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("v1/swagger.json", "API v1");
                options.RoutePrefix = "swagger";
                });
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

