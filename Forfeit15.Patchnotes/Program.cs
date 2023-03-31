using System.Text.Json.Serialization;
using Forfeit15.Patchnotes.Core.Patchnotes.Services;
using Forfeit15.Patchnotes.Core.Patchnotes.Services.Implementations;
using Forfeit15.Patchnotes.Postgres.Extensions;
using Forfeit15.Postgres.Contexts;
using Forfeit15.Postgres.Extensions;

//HOST
var builder = WebApplication.CreateBuilder(args);

//CONFIGURATION

//INJECTED SERVICES
builder.Services.AddPatchNotePostgres(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPatchnoteService, PatchnoteService>();

builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//APP
var app = builder.Build();

//LOGGING

//SWAGGER
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabases();
app.MapControllers();

app.Run();