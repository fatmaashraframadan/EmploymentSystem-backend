using API.Application.Models;
using API.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ITokenService _tokenService;


    public AccountController(UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration
    , ITokenService tokenService)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Ensure the role exists
                var roleExist = await _roleManager.RoleExistsAsync(model.Role);
                if (!roleExist)
                {
                    return BadRequest(new { message = $"Role '{model.Role}' does not exist." });
                }

                // Assign the user to the specified role
                await _userManager.AddToRoleAsync(user, model.Role);

                // Optionally, sign in the user after successful registration
                await _signInManager.SignInAsync(user, isPersistent: false);

                return Ok(new { token = JwtHelper.GenerateJwtToken(user, _configuration) });
            }

            return BadRequest(result.Errors);
        }

        return BadRequest("Invalid registration details");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded)
        {
            return Unauthorized("Invalid username or password.");
        }

        // Generate token using Identity
        var token = await _tokenService.GenerateToken(user);
        if (string.IsNullOrEmpty(token))
        {
            return StatusCode(500, "Token generation failed.");
        }

        return Ok(new
        {
            access_token = token,
            email = user.Email
        });
    }
}