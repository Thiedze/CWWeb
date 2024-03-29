using Service.Users.Domain;

namespace Service.Authorizations.Domain;

public class AuthenticateResponse
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Username { get; }
    public string Token { get; }


    public AuthenticateResponse(User user, string token)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Username = user.Username;
        Token = token;
    }
}