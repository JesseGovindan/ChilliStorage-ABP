using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ChilliStorage.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ChilliStorageDbContextFactory : IDesignTimeDbContextFactory<ChilliStorageDbContext>
{
    public ChilliStorageDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        ChilliStorageEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<ChilliStorageDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), MySqlServerVersion.LatestSupportedServerVersion);
        
        return new ChilliStorageDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ChilliStorage.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
