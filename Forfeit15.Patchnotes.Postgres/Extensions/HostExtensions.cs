using Forfeit15.Postgres.Contexts;
using Forfeit15.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Forfeit15.Patchnotes.Postgres.Extensions;

public static class HostExtensions
{
    public static void MigrateDatabases(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        scope.ServiceProvider.GetRequiredService<PatchNoteDbContext>().Database.EnsureCreated();
        
        host.MigrateDatabase<PatchNoteDbContext>();
    }
}