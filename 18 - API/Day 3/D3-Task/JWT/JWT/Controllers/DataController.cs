using JWT.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        #region Injection
        private readonly UserManager<ApplicationUser> _userManager;

        public DataController(UserManager<ApplicationUser> userManager)
        {
           _userManager = userManager;
        }
        #endregion

        #region Login Users Data



        [HttpGet]
        public async Task<ActionResult> GetUserData()
        {
            var user = await _userManager.GetUserAsync(User);
            return Ok(new 
            {
                Data = "The username =" + user.UserName
                            + "\n" + "Email : " + user.Email
                             + "\n" + "Role : " + user.UserRole
            });
        }
        #endregion


        #region Data For Admin
        [HttpGet]
        [Route("Admin")]
        [Authorize(Policy = "AllowAdmin")]
        public ActionResult GetDataForAdmins()
        {
            return Ok(new { Data = "This is For Admins Only" });
        }
        #endregion

        #region Data For Users
        [HttpGet]
        [Route("User")]
        [Authorize(Policy = "AllowUser")]
        public ActionResult GetDataForUser()
        {
            return Ok(new { Data="This Data For Users Only" });
        }
        #endregion



    }
}
