using System.Dynamic;
using feastly_api.Models;

namespace feastly_api.Repositories;

public interface IAuthService
{
    User CreateUser(User user);
    ExpandoObject SignIn(string email, string password);
}