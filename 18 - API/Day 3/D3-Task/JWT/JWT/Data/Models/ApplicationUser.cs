
using Microsoft.AspNetCore.Identity;

namespace JWT.Data;

public class ApplicationUser:IdentityUser
{
    public string UserRole { get; set; } = string.Empty;
}
