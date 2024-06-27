using Fiap.Api.Alunos.Exceptions;
using Fiap.Api.Alunos.Services;
using Fiap.Api.Alunos.ViewModels;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] UserViewModel userViewModel)
    {
        try
        {
            var user = _userService.Register(userViewModel);
            return Ok(user);
        }
        catch (CustomException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginViewModel userLoginViewModel)
    {
        try
        {
            var user = _userService.Login(userLoginViewModel);
            return Ok(user);
        }
        catch (CustomException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpGet("{email}")]
    public IActionResult GetUserByEmail(string email)
    {
        try
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
