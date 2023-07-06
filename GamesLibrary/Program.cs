using System;
using GamesLibrary.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using NLog;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace GamesLibrary;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();

        var startup = new Startup(builder.Configuration, builder.Environment);
        startup.ConfigureServices(builder.Services);
        var app = builder.Build();

        startup.Configure(app);

        try
        {
            app.Run();
        }
        catch (Exception e)
        {
            app.Logger.LogCritical(e, "Failed to start application");
        }
        finally
        {
            LogManager.Shutdown();
        }
    }
   
}