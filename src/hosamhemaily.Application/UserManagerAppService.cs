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
    [RemoteService(IsEnabled =false)]
    public class UserManagerAppService : ApplicationService, IUserManagerAppService
    {
        private static int _sessionDuration = 100;

        private IConfiguration _configuration;

        private readonly IdentityUserManager _userManager;
        private readonly IRepository<IdentityRole, Guid> _roleRepository;


        public UserManagerAppService(IdentityUserManager userManager,
            IConfiguration configuration,
            IRepository<IdentityRole, Guid> roleRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleRepository = roleRepository;
        }
        public async Task<string> CreateTokenAync(LoginDTO dTO)
        {

            //hosamhemaily
            var user = await _userManager.FindByNameAsync(dTO.UserName);
            if (user == null)
            {
                // User does not exist, throw a custom exception
                throw new UserFriendlyException("User does not exist", "USER_NOT_FOUND");
            }
            //var roles = _roleManager.Roles.ToList();
            var roles = await _userManager.GetRolesAsync(user);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKeyThatIsLongEnough12345"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, dTO.UserName),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }



    }
}
