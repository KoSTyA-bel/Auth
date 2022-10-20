namespace Authentication.BusinessLayer.Interfaces;

public interface IJWTWorker
{
    Task<string> GenerageToken(string userName, CancellationToken cancellationToken);

    Task<string> ValidateToken(string token, CancellationToken cancellationToken);
}
