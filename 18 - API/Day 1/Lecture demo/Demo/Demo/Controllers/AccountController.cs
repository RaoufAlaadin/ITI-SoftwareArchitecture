using Demo.DTO;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        // This will be cleaner because We do not need the GET Actions,
        // They viewing of forms is handled by angular. 

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }


        // Create Account new User "Registeration" => Post


        [HttpPost("register")] //api/Account/register

        public async Task<IActionResult> Registeration(RegisterUserDTO userDTO) { 
        
        
            // How to save into database? using the `injected` UserManger.
            // UserManger is the service Layer for the identity.


            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = userDTO.Username,
                    Email = userDTO.Email
                };

                // Will use the `overload`that takes password and hash it. 
                IdentityResult result = await userManager.CreateAsync(user, userDTO.Password);


                if (result.Succeeded) { return Ok("Account Add Success"); }

                // We could have made a foreach to get all errors into a list
                // and send it in the bad request.
                return BadRequest(result.Errors.FirstOrDefault());
            }

            // It's better to create a DTO to give us what we want from the ModelState,
            //Instead of getting the whole object back. 
            return BadRequest(ModelState); 

        }

        // Check Account Valid "Login" => Post 

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO userDTO)
        {
            if(ModelState.IsValid == true)
            {
                // check = create token 

               ApplicationUser user = await userManager.FindByNameAsync(userDTO.UserName);

                if (user != null)
                {
                   bool found = await userManager.CheckPasswordAsync(user, userDTO.Password);

                    if(found)
                    {
                        // Claims token 

                        var claimsList = new List<Claim>()
                        {
                            // Random strings by microsoft. 
                            new Claim(ClaimTypes.Name,user.UserName),
                            new Claim(ClaimTypes.NameIdentifier,user.Id),
                            // list of default claims used by the jwt standard 
                            // JTI is => json token identifier, which is a unique 

                            // that's why we used Guid to create a unique string each time.
                            // Guid => globally unique identifer.
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            

                        };


                        // get role => return a list of roles that the user have.

                        var roles = await userManager.GetRolesAsync(user);

                        foreach(var itemRole in roles)
                        {
                            claimsList.Add(new Claim(ClaimTypes.Role, itemRole));
                        }


                        //Credintials object
                        // symmetric => used for both encrypting and de-crypting.
                        SecurityKey securityKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config["JWT:Secret"]));

                        SigningCredentials sigincred = new SigningCredentials
                            (securityKey, SecurityAlgorithms.HmacSha256);
                            
                        // create token 

                        // This class is only for representation, the creation is done
                        // by the `handler`. 
                        JwtSecurityToken myToken = new JwtSecurityToken(
                            
                            issuer: config["JWT:ValidIssure"], // our api link
                            audience: config["JWT:ValidAudiance"], // consumer URL (angular)
                            claims: claimsList,
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: sigincred // Key used for encrypting.
                           );


                        return Ok(new { 
                             // handler creates a new instance of a token 
                             // writeToken serialize the token into compact form xxxx.xxxx.xxxx 
                            token = new JwtSecurityTokenHandler().WriteToken(myToken),
                            expiration = myToken.ValidTo
                        
                        });

                    }
                }

                return Unauthorized();
            }

            return Unauthorized();
        }

    }
}
