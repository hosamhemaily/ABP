using DTO;
using hosamhemaily.DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using static Volo.Abp.Identity.IdentityPermissions;

namespace hosamhemaily
{
    public class UserManagerAppService : ApplicationService, IUserManagerAppService
    {
        private static int _sessionDuration = 100;

        private IConfiguration _configuration;

        private readonly IdentityUserManager _userManager;

        public UserManagerAppService(IdentityUserManager userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;

        }
        public async Task<string> CreateTokenAync(LoginDTO dTO)
        {
            var user =  await _userManager.FindByEmailAsync(dTO.UserName);
            var resultsignin= await _userManager.CheckPasswordAsync(user, dTO.Password);
            var userroles =  await _userManager.GetRolesAsync(user);
            if (!resultsignin)
            {
                throw new UserFriendlyException("User Cant sign in"); 
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>  
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"]),
            new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:audience"]),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
        };
            foreach (var item in userroles)
            {
                claims.Add(new Claim(ClaimTypes.Role, string.Join(",", item)));
            }
            var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(1),
            signingCredentials: credentials
        );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
