using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWT.Data;

public class APPContext:IdentityDbContext<ApplicationUser>
{
	public APPContext(DbContextOptions<APPContext> options):base(options)
	{
			
	}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>().ToTable("Application Users");
        builder.Entity<IdentityUserClaim<string>>().ToTable("ApplicationUSersCalims");
    }
}
