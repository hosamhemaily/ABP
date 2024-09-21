using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;

public class TokenManager : ITokenManager, ITransientDependency
{
    //private readonly UserManager<User> _userManager;
    //private readonly IPermissionManager _permissionManager;

    public TokenManager()
    {
        //_userManager = userManager;
        //_permissionManager = permissionManager;
    }

}
