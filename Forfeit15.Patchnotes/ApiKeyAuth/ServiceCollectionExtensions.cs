using AspNetCore.Authentication.ApiKey;

namespace Forfeit15.Patchnotes.ApiKeyAuth;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiKeyAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(ApiKeyAuthConstants.AuthenticationScheme)
            .AddApiKeyInHeader(ApiKeyAuthConstants.AuthenticationScheme, options =>
                {
                    options.Realm = configuration.GetValue<string>("Api:Title");
                    options.KeyName = ApiKeyAuthConstants.Header;
                    options.Events = new ApiKeyEvents
                    {
                        OnValidateKey = context =>
                        {
                            var apiKey = context.Request.Headers.Authorization;
                            var isValid = apiKey == configuration.GetValue<string>(ApiKeyAuthConstants.ConfigurationKey);

                            if (isValid)
                            {
                                context.ValidationSucceeded();
                            }
                            else
                            {
                                context.ValidationFailed();
                            }

                            return Task.CompletedTask;
                        }
                    };
                }
            );

        return services;
    }

}