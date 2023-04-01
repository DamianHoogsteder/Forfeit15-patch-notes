using System.Text.Json.Serialization;
using Forfeit15.Patchnotes.ApiKeyAuth;
using Forfeit15.Patchnotes.Core.Patchnotes.Services;
using Forfeit15.Patchnotes.Core.Patchnotes.Services.Implementations;
using Forfeit15.Patchnotes.Postgres.Extensions;
using Forfeit15.Patchnotes.Postgres.Repositories;
using Forfeit15.Patchnotes.Postgres.Repositories.Implementations;
using Forfeit15.Postgres.Contexts;
using Forfeit15.Postgres.Extensions;


//HOST
var builder = WebApplication.CreateBuilder(args);

//CONFIGURATION

//INJECTED SERVICES
builder.Services.AddPatchNotePostgres(builder.Configuration);
builder.Services.AddApiKeyAuth(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.AddApiKeyAuth());
builder.Services.AddTransient<IPatchnoteService, PatchnoteService>();
builder.Services.AddTransient<IPatchnoteRepository, PatchnoteRepository>();

builder.Services
    .AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MigrateDatabases();
app.MapControllers();

app.Run();