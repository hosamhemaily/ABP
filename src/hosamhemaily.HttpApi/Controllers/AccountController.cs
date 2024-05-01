//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp.Account;
//using Volo.Abp.AspNetCore.Mvc;
//using Volo.Abp.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Volo.Abp;

//namespace hosamhemaily.Controllers
//{
//    [RemoteService(Name = AccountRemoteServiceConsts.RemoteServiceName)]
//    [Area(AccountRemoteServiceConsts.ModuleName)]

//    [Route("api/account")]
//    public class AccountController : AbpControllerBase, IAccountAppService
//    //{

//        public Task<IdentityUserDto> LoginAsync(RegisterDto input)
//        {
//            throw new NotImplementedException();
//        }
//        public Task<IdentityUserDto> RegisterAsync(RegisterDto input)
//        {
//            throw new NotImplementedException();
//        }

//        public Task ResetPasswordAsync(ResetPasswordDto input)
//        {
//            throw new NotImplementedException();
//        }

//        public Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> VerifyPasswordResetTokenAsync(VerifyPasswordResetTokenInput input)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
