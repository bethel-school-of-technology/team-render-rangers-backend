using System.Dynamic;
using feastly_api.Models;
using feastly_api.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace feastly_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService service)
    {
        _logger = logger;
        _authService = service;
    }

    [HttpPost]
    [Route("register")]
    public ActionResult CreateUser(User user)
    {
        if (user == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        _authService.CreateUser(user);
        return NoContent();
    }

    [HttpGet]
    [Route("login")]
    public ActionResult<ExpandoObject> SignIn(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            return BadRequest();
        }

        var userWithToken = _authService.SignIn(email, password);

        //if (userWithToken)
        //{
        //    return Unauthorized();
        //}

        return Ok(userWithToken);
    }
}