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
        public async Task<Guid> CreateAsync(PriceOffer priceoffer)
        {
            Entity entity1 = new Entity("vl_pricelistrequest");
            //entity1[""] = priceoffer.AccountTrademark;
            var guid =  await _crmServiceBase.CrmClient.CreateAsync(entity1);
            Entity entityPriceListVehicle = new Entity("vl_pricelistvehicle");
            entityPriceListVehicle["vl_priceid"] = new EntityReference() { Id= guid };
            entityPriceListVehicle["vl_accounttrademarkspecs"] = new EntityReference() { Id= priceoffer.AccountTrademarkId };
            var pricevehicleid = await _crmServiceBase.CrmClient.CreateAsync(entityPriceListVehicle);

            return guid;
        }

        public Task<List<PriceOffer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
