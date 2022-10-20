namespace Authentication.BusinessLayer.Settings;

public class JWTWorkerSettings
{
    public int LifeTimeInHours { get; set; }

    public string Key { get; set; } = string.Empty;

    public string Issuer { get; set; } = string.Empty;

    public string Audience { get; set; } = string.Empty;
}
