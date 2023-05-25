using Forfeit15.Postgres.Contexts;
using Forfeit15.Postgres.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Forfeit15.Patchnotes.Postgres.Extensions;

public static class HostExtensions
 {
     public static void MigrateDatabases(this IHost host)
     {
         using var scope = host.Services.CreateScope();
         var dbContext = scope.ServiceProvider.GetRequiredService<PatchNoteDbContext>();
         
         // Migrate the database to the latest version
         host.MigrateDatabase<PatchNoteDbContext>();
     }
 }