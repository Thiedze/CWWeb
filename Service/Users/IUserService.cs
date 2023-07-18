using System.Collections.Generic;
using Service.Authorizations.Domain;
using Service.Users.Domain;

namespace Service.Users;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model, string secret);
    List<User> GetAll();
    User GetById(int id);
}