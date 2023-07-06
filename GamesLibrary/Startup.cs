using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using GamesLibrary.Extensions;
using GamesLibrary.HealthCheck;
using GamesLibrary.HostedServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace GamesLibrary;

public class Startup
{
    private readonly IWebHostEnvironment _env;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        _env = env;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHealthChecks().AddCheck<GamesLibraryHealthCheck>("games_library_health_check");



        services
            .AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


        services.AddHostedService<AppInitService>();

        services.AddRepositories();
        services.AddService();
        services.AddSwaggerGen();


    }

    public void Configure(IApplicationBuilder app)
    {

        app.UseHealthChecks("/healthcheck");//страничка для проверки состояния, добавление middleware healthcheck 

        app.UseDeveloperExceptionPage(); //добавление странички с ошибкой только в режиме дебага
        app.UseSwagger();

        app.UseSwaggerUI(
            c =>
            {
                c.SwaggerEndpoint("../swagger/v3/swagger.json", "GamesLibraryApi");
                c.SwaggerEndpoint("../swagger/local/swagger.json", "My Local API");
            });
        app.Use(async (context, next) =>
        {
            context.Request.EnableBuffering();
            await next();
        });


        app.UseRouting();
        app.UseCors();

        app.UseEndpoints(
            endpoints => { endpoints.MapControllers(); });

        app.UseWebSockets();

    }
}

