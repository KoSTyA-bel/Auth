namespace Authentication.BusinessLayer.Settings;

/// <summary>
/// Class providing settings for <see cref="Worker.JWTWorker"/>
/// </summary>
public class JWTWorkerSettings
{
    /// <summary>
    /// Gets or sets the life time in hours.
    /// </summary>
    /// <value>
    /// The life time in hours.
    /// </value>
    public int LifeTimeInHours { get; set; }

    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    /// <value>
    /// The key.
    /// </value>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the issuer.
    /// </summary>
    /// <value>
    /// The issuer.
    /// </value>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the audience.
    /// </summary>
    /// <value>
    /// The audience.
    /// </value>
    public string Audience { get; set; } = string.Empty;
}
