using feastly_api.Models;
using feastly_api.Migrations;

using System.Text;
using System.Security.Claims;
using bcrypt = BCrypt.Net.BCrypt;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Dynamic;

namespace feastly_api.Repositories;

public class AuthService : IAuthService
{
    private static RecipeDbContext _context;
    private static IConfiguration _config;

    public AuthService(RecipeDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public User CreateUser(User user)
    {
        var passwordHash = bcrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        _context.Add(user);
        _context.SaveChanges();
        return user;
    }

    public ExpandoObject SignIn(string email, string password)
    {
        var user = _context.Users.SingleOrDefault(x => x.Email == email);
        var verified = false;

        if (user != null)
        {
            verified = bcrypt.Verify(password, user.Password);
        }

        if (user == null || !verified)
        {
            return new ExpandoObject();
        }

        // user.token = BuildToken(user);

        dynamic userWithToken = new ExpandoObject();
        userWithToken.token = BuildToken(user);
        userWithToken.UserId = user.UserId;
        userWithToken.Email = user.Email;
        userWithToken.Name = user.Name;


        return userWithToken;
    }

    private string BuildToken(User user)
    {
        var secret = _config.GetValue<String>("TokenSecret");
        var signignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var signingCredentials = new SigningCredentials(signignKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
             new Claim("UserId", user.UserId.ToString()), // added UserId claim
            new Claim(JwtRegisteredClaimNames.Name, user.Name ?? "")
        };

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30), // increased time
            signingCredentials: signingCredentials);

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }
}