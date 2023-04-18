using JWT.Data;
using JWT.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace JWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppUserController : ControllerBase
{
    #region Injection
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;

    public AppUserController(IConfiguration configuration , UserManager<ApplicationUser> userManager)
    {
       _configuration = configuration;
        _userManager = userManager;
    }
    #endregion


    #region Admin Register
    [HttpPost]
    [Route("AdminRegisteration")]
    public async Task<ActionResult> RegisterAdmin(RegisterDto RegisterDto)
    {
        var userExists = await _userManager.FindByEmailAsync(RegisterDto.Email);
        if (userExists != null)
        {
            return BadRequest("User already exists");
        }

        var UserToAdd = new ApplicationUser
        {
            UserName = RegisterDto.UserName,
            Email = RegisterDto.Email,
            UserRole = RegisterDto.UserRole
        };

        var Result = await _userManager.CreateAsync(UserToAdd, RegisterDto.Password);
        if (!Result.Succeeded)
        {
            return BadRequest(Result.Errors);
        }
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier , UserToAdd.Id),
            new Claim(ClaimTypes.Role, "Admin")
        };

        await _userManager.AddClaimsAsync(UserToAdd, claims);
        return NoContent();


    }
    #endregion

    #region User Register
    [HttpPost]
    [Route("User Registeration")]
     public async Task<ActionResult>Register(RegisterDto RegisterDto)
    {
        var UserToAdd = new ApplicationUser
        {
            UserName = RegisterDto.UserName,
            Email = RegisterDto.Email,
            UserRole = RegisterDto.UserRole
        };

        var Result = await _userManager.CreateAsync(UserToAdd, RegisterDto.Password);
        if (!Result.Succeeded)
        {
            return BadRequest(Result.Errors);
        }
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier , UserToAdd.Id),
            new Claim(ClaimTypes.Role , "User")
        };

        await _userManager.AddClaimsAsync(UserToAdd, claims);
        return NoContent();


    }
    #endregion 

    #region Login

    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<TokenDto>> Login_Clean(LogInDto credentials)
    {
        var user = await _userManager.FindByNameAsync(credentials.UserName);
        if (user == null)
        {
            return NotFound();
        }

        var isAuthenitcated = await _userManager.CheckPasswordAsync(user, credentials.Password);
        if (!isAuthenitcated)
        {
            return Unauthorized();
        }

        var claimsList = await _userManager.GetClaimsAsync(user);

        var secretKeyString = _configuration.GetValue<string>("SecretKey") ?? string.Empty;
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
        var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

        //Combination SecretKey, HashingAlgorithm
        var siginingCreedentials = new SigningCredentials(secretKey,
            SecurityAlgorithms.HmacSha256Signature);

        var expiry = DateTime.Now.AddDays(1);

        var token = new JwtSecurityToken(
            claims: claimsList,
            expires: expiry,
            signingCredentials: siginingCreedentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = tokenHandler.WriteToken(token);

        return new TokenDto(tokenString, expiry);
    }

    #endregion 


}
