using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gabbetto.Word.Web.Server
{
    public static class JwtTokenExtensionMethods
    {
        /// <summary>
        /// Generates a Jwt bearer token containing the users username
        /// </summary>
        /// <param name="user">The users details</param>
        /// <returns></returns>
        public static string GenerateToken(this ApplicationUser user)
        {
            // Set our tokens claims
            var claims = new[]
            {
                // Unique ID for this token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),                

                // The username using the Identity name so it fills out the HttpContext.User.Identity.Name value
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),

                // Set the Email as a claim of this token
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            // Create the credentials used to generate the token
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IocContainer.Configuration["Jwt:SecretKey"])),
                SecurityAlgorithms.HmacSha256);

            // Generate the Jwt token
            var token = new JwtSecurityToken(
                issuer: IocContainer.Configuration["Jwt:Issuer"],
                audience: IocContainer.Configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: credentials
                );

            // Return the generated token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
