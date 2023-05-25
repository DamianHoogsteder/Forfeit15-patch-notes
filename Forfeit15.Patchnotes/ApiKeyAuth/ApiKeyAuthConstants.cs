namespace Forfeit15.Patchnotes.ApiKeyAuth;

public static class ApiKeyAuthConstants
{
    /// <summary>
    /// Defines in which header the API-key should be passed
    /// </summary>
    public const string Header = "Authorization";

    /// <summary>
    /// Defines the ASP.NET Core Authentication Scheme to use
    /// </summary>
    public const string AuthenticationScheme = "CustomApiKeyAuthentication";

    /// <summary>
    /// Defines the configuration key in which the API-key can be found
    /// </summary>
    public const string ConfigurationKey = "Api:ApiKey";
}
