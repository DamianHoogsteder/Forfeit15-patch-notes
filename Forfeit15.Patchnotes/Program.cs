using System.Text.Json.Serialization;
using Forfeit15.Patchnotes.ApiKeyAuth;
using Forfeit15.Patchnotes.Core.Messaging;
using Forfeit15.Patchnotes.Core.Patchnotes.Services.InfoNodes;
using Forfeit15.Patchnotes.Core.Patchnotes.Services.InfoNodes.Implementations;
using Forfeit15.Patchnotes.Core.Patchnotes.Services.Patchnotes;
using Forfeit15.Patchnotes.Core.Patchnotes.Services.Patchnotes.Implementations;
using Forfeit15.Patchnotes.Postgres.Extensions;
using Forfeit15.Patchnotes.Postgres.Repositories.InfoNodes;
using Forfeit15.Patchnotes.Postgres.Repositories.InfoNodes.Implementations;
using Forfeit15.Patchnotes.Postgres.Repositories.PatchNotes;
using Forfeit15.Patchnotes.Postgres.Repositories.PatchNotes.Implementations;
using Forfeit15.Postgres.Extensions;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;

// HOST
var builder = WebApplication.CreateBuilder(args);

// CONFIGURATION
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Seq("http://localhost:80")
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Services.AddSerilog(logger);

// INJECTED SERVICES
builder.Services.AddPatchNotePostgres(builder.Configuration);
builder.Services.AddApiKeyAuth(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.AddApiKeyAuth());
builder.Services.AddTransient<IPatchnoteService, PatchnoteService>();
builder.Services.AddTransient<IPatchnoteRepository, PatchnoteRepository>();
builder.Services.AddTransient<IInfoNodeService, InfoNodeService>();
builder.Services.AddTransient<IInfoNodeRepository, InfoNodeRepository>();
builder.Services.AddSingleton<MessageService>(new MessageService(
    "amqp://lxwoxkvq:tkjW4M8P7fOj-jM7Yu9I4-yTiKYj-yIK@cow.rmq2.cloudamqp.com/lxwoxkvq", "forfeit15-updates"));

builder.Services
    .AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddOpenTelemetryTracing(builder =>
{
    builder
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Forfeit15.Patchnotes.Traces"))
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddJaegerExporter();
});

// APP
var app = builder.Build();

// LOGGING

// SWAGGER
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MigrateDatabases();
app.MapControllers();

app.Run();