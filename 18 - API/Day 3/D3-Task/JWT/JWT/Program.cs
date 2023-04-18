using JWT.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Cors

var corsPolicy = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, p => p.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

#endregion

#region Default

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Database

var connectionString = builder.Configuration.GetConnectionString("ConnectionName");
builder.Services.AddDbContext<APPContext>(options =>
    options.UseSqlServer(connectionString));

#endregion

#region Identity Managers

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<APPContext>();

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    //Used Authentication Scheme
    options.DefaultAuthenticateScheme = "MYAuthentication";

    //Used Challenge Authentication Scheme
    options.DefaultChallengeScheme = "MYAuthentication";
})
    .AddJwtBearer("MYAuthentication", options =>
    {
        var secretKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
        var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = secretKey,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

#endregion

#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AllowAdmin", policy => policy
        .RequireClaim(ClaimTypes.Role, "Admin")
        .RequireClaim(ClaimTypes.NameIdentifier));

    options.AddPolicy("AllowUser", policy => policy
        .RequireClaim(ClaimTypes.Role, "User"));
});

#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
