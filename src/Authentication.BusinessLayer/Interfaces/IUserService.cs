using Authentication.BusinessLayer.Models;

namespace Authentication.BusinessLayer.Interfaces;

public interface IUserService
{
    Task<User> GetUser(string userName, string password, CancellationToken token);

    Task<User> GetUserByName(string userName, CancellationToken token);
}
