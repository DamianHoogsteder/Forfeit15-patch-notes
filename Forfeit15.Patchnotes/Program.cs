using System.Diagnostics.CodeAnalysis;
using Forfeit15.Patchnotes.Postgres.Extensions;
using Forfeit15.Postgres.Contexts;
using Forfeit15.Postgres.Extensions;

//HOST
    var builder = WebApplication.CreateBuilder(args);

//CONFIGURATION

//INJECTED SERVICES
    builder.Services.AddPatchNotePostgres(builder.Configuration);
    
//APP
    var app = builder.Build();

//LOGGING

//SWAGGER
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MigrateDatabases();
    app.MapControllers();

    app.Run();


[ExcludeFromCodeCoverage]
#pragma warning disable CA1050
public partial class Program
#pragma warning restore CA1050
{
}
