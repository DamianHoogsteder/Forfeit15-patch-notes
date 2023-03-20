void RunAction()
{

//HOST
    var builder = WebApplication.CreateBuilder(args);

//CONFIGURATION

//INJECTED SERVICES

//APP
    var app = builder.Build();

//LOGGING

//SWAGGER
    app.UseSwagger();
    app.UseSwaggerUi<Program>(options =>
        {
            var applicationOptions = app.Services.GetRequiredService<IOptions<Auth0ApplicationOptions>>();
            options.PopulateAuth0AuthorizationForm(applicationOptions);
        }
    );

//AUTHENTICATION MIDDLEWARE
    app.MapControllers();

    app.Run();
}

await HostRunner.RunAsync(RunAction);

[ExcludeFromCodeCoverage]
#pragma warning disable CA1050
public partial class Program
#pragma warning restore CA1050
{
}
