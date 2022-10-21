namespace Authentication.BusinessLayer.Models;

/// <summary>
/// Describe entity.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    /// <value>
    /// The password.
    /// </value>
    public string Password { get; set; } = string.Empty;
}
