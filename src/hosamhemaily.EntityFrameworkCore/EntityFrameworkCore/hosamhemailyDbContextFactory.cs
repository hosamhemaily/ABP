using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace hosamhemaily.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class hosamhemailyDbContextFactory : IDesignTimeDbContextFactory<hosamhemailyDbContext>
{
    public hosamhemailyDbContext CreateDbContext(string[] args)
    {
        hosamhemailyEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<hosamhemailyDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new hosamhemailyDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../hosamhemaily.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
