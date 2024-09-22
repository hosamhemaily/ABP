using Data8.PowerPlatform.Dataverse.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosamhemaily
{
    public class CrmServiceBase
    {
        private readonly ILogger<CrmServiceBase> _logger;
        private readonly IConfiguration _configuration;

        public CrmServiceBase(IConfiguration configuration, ILogger<CrmServiceBase> logger) {
            try
            {
                _logger = logger;
                _configuration = configuration;
                var url = _configuration.GetValue<string>("ConnectionStrings:crm:url");
                var username = _configuration.GetValue<string>("ConnectionStrings:crm:username");
                var password = _configuration.GetValue<string>("ConnectionStrings:crm:password");

                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, certificate, chain, errors) =>
                    {
                        return true;
                    };
                CrmClient = new OnPremiseClient(url, username, password);
            }
            catch (Exception ex)
            {

                _logger.LogCritical(ex.Message);
            }
        }

        public OnPremiseClient CrmClient { get; set; }

    }
}
