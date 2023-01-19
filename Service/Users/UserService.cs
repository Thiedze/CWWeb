using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Service.Authorizations.Domain;
using Service.Database;
using Service.Users.Domain;

namespace Service.Users;

public class UserService : IUserService
{
    private static int KeySize => 64;
    private static int Iterations => 350000;
    private byte[] Salt { get; } = {0x21, 0x23, 0x40, 0x10, 0x80, 0x00, 0x40};
    private HashAlgorithmName HashAlgorithm { get; } = HashAlgorithmName.SHA512;

    public AuthenticateResponse? Authenticate(AuthenticateRequest model, string secret)
    {
        using var dataContex = new DataContext();
        var users = dataContex.Users?.Where(user => user.Username == model.Username);

        // return null if user not found or more then one exists
        if (users == null || users.ToList().Count != 1)
        {
            return null;
        }

        if (model.Password != null)
        {
            var hashedPassword = HashPassword(model.Password);

            if (hashedPassword == users.First().Password)
            {
                // authentication successful so generate jwt token
                var token = GenerateJwtToken(users.First(), secret);
                return new AuthenticateResponse(users.First(), token);   
            }   
        }

        throw new Exception();
    }

    public IEnumerable<User> GetAll()
    {
        return null;
    }

    public User GetById(int id)
    {
        throw new NotImplementedException();
    }

    private string HashPassword(string password)
    {
        var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), Salt, Iterations, HashAlgorithm,
            KeySize);
        return Convert.ToHexString(hash);
    }

    private static string GenerateJwtToken(User user, string secret)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {new Claim("id", user.Id.ToString())}),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}