namespace FastFoodApp.Infrastructure.Configuration;

public class OAuthSettings
{
    public GoogleSettings Google { get; set; } = new();
    public FacebookSettings Facebook { get; set; } = new();
}

public class GoogleSettings
{
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}

public class FacebookSettings
{
    public string AppId { get; set; } = string.Empty;
    public string AppSecret { get; set; } = string.Empty;
}
