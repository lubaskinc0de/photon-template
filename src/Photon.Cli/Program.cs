using System.CommandLine;
using Microsoft.EntityFrameworkCore;
using Photon.Infrastructure.Data;
using Microsoft.Extensions.Hosting;
using Photon.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Photon.Cli;

public class Program
{
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        var migrateCommand = new Command("migrate", "perform app migrations");
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        Injector.Inject(builder);

        rootCommand.AddCommand(migrateCommand);
        migrateCommand.SetHandler(() =>
            {
                using var host = builder.Build();
                return PerformMigrations(host);
            });
        return await rootCommand.InvokeAsync(args);
    }

    static async Task PerformMigrations(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await db.Database.MigrateAsync();
    }
}
