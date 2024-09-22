using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace hosamhemaily
{
    public interface ITokenAppService : IApplicationService
    {
        Task<string> GenerateToken(TokenInputDto tokenInput);
        
    }

   
}
