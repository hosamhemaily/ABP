using hosamhemaily.Entities.PriceOffer;
using hosamhemaily.Repositorys;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosamhemaily
{
    public class PriceOfferRepository : IPriceOfferRepository
    {
        private readonly CrmServiceBase _crmServiceBase;

        public PriceOfferRepository(CrmServiceBase crmServiceBase)
        {
                _crmServiceBase=crmServiceBase;
        }
        public Task<Guid> CreateAsync(PriceOffer priceoffer)
        {
            Entity entity1 = new Entity("vl_pricelistrequest");
            //entity1[""] = priceoffer.AccountTrademark;
            _crmServiceBase.CrmClient.Create(entity1);
            throw new NotImplementedException();
        }

        public Task<List<PriceOffer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
