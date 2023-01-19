using System.ComponentModel.DataAnnotations;

namespace Service.Authorizations.Domain;

public class AuthenticateRequest
{
    [Required] public string? Username { get; set; }

    [Required] public string? Password { get; set; }
}