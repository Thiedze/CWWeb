using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SelfHosted.Controller.V1.Authorizations.Domain;
using Service.Authorizations.Domain;
using Service.Users;

namespace SelfHosted.Controller.V1.User;

[ApiController]
public class UsersController : ControllerBase
{
    private IUserService UserService { get; }
    private IMapper Mapper { get; }
    private AppSettings AppSettings { get; }

    public UsersController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
    {
        UserService = userService;
        Mapper = mapper;
        AppSettings = appSettings.Value;
    }

    [HttpPost]
    [Route(UrlConfiguration.V1ApiUrl + "/users/authenticate")]
    public IActionResult Authenticate(AuthenticateRequestDto model)
    {
        var response = UserService.Authenticate(Mapper.Map<AuthenticateRequestDto, AuthenticateRequest>(model),
            AppSettings.Secret);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [Authorize]
    [HttpGet]
    [Route(UrlConfiguration.V1ApiUrl + "/users")]
    public IActionResult GetAll()
    {
        var users = UserService.GetAll();
        return Ok(users);
    }
}