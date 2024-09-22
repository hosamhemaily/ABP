using DTO;
using hosamhemaily.DomainServices;
using hosamhemaily.Repositorys;

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Users;



namespace hosamhemaily
{
    //[Authorize]
    public class TokenAppService : ApplicationService, ITokenAppService
    {
        
        private readonly IdentityUserManager _userManager; 
        private readonly IRepository<IdentityRole, Guid> _roleRepository;

        public TokenAppService(
            IdentityUserManager userManager,
            IRepository<IdentityRole, Guid> roleRepository)

        {
            _userManager = userManager;
            _roleRepository = roleRepository;
        }

        public async Task<string> GenerateToken(TokenInputDto tokenInput)
        {
            var user = await _userManager.FindByNameAsync(tokenInput.UserName);
            if (user == null)
            {
                // User does not exist, throw a custom exception
                throw new UserFriendlyException("User does not exist", "USER_NOT_FOUND");
            }
            //var roles = _roleManager.Roles.ToList();
            var roles = await _roleRepository.GetListAsync();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKeyThatIsLongEnough12345"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, tokenInput.UserName),
            };
            
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
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
