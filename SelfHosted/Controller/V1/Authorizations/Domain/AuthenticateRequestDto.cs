using System.ComponentModel.DataAnnotations;

namespace SelfHosted.Controller.V1.Authorizations.Domain;

public class AuthenticateRequestDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}