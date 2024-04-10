// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Wj.Bizlogic.Test;

Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

try
{
    Log.Information("Starting console host.");

    var builder = Host.CreateApplicationBuilder(args);
    builder.Logging.ClearProviders().AddSerilog();
    builder.ConfigureContainer(builder.Services.AddAutofacServiceProviderFactory());
    builder.Services.AddHostedService<MyConsoleAppHostedService>();
    await builder.Services.AddApplicationAsync<MyConsoleAppModule>();

    var host = builder.Build();
    await host.InitializeAsync();
    await host.RunAsync();

    Console.ReadKey();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly!");
}
finally
{
    Log.CloseAndFlush();
}