//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp.AspNetCore.Mvc;
//using Volo.Abp.Users;
//using static Volo.Abp.Identity.Settings.IdentitySettingNames;

//namespace hosamhemaily.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TokenController : AbpControllerBase
//    {
//        private readonly IdentityUserManager _userManager;
//        //private readonly IConfiguration _configuration;
//        public TokenController(UserManager<AbpUserConsts> userManager)
//        {
//            _userManager = userManager;
//            //_configuration = configuration;
//        }

//        [HttpGet]
//        public async Task< bool> GetData()
//        {
//            var user = await  _userManager.FindByEmailAsync("admin@abp.io");
//            var result =  await _userManager.CreateSecurityTokenAsync(user);
//            return true;
//        }
//    }
//}
