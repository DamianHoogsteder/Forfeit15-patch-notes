using AspNetCore.Authentication.ApiKey;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Forfeit15.Patchnotes.ApiKeyAuth;

public static class SwaggerGenOptionsExtensions
{
    public static void AddApiKeyAuth(this SwaggerGenOptions options)
    {
        options.AddSecurityDefinition(ApiKeyDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Name = ApiKeyAuthConstants.Header,
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = ApiKeyAuthConstants.AuthenticationScheme
            }
        );
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = ApiKeyDefaults.AuthenticationScheme
                        }
                    },
                    Array.Empty<string>()
                }
            }
        );
    }
}