using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GymManagementSystem.Data.Context;

public class GymDbContextFactory
    : IDesignTimeDbContextFactory<GymDbContext>
{
    public GymDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<GymDbContext>();

        var connectionString =
            Environment.GetEnvironmentVariable(
                "GYM_DB_CONNECTION"
            );

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "GYM_DB_CONNECTION environment variable is not configured."
            );
        }

        optionsBuilder.UseSqlServer(connectionString);

        return new GymDbContext(optionsBuilder.Options);
    }
}