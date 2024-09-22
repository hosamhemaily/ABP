using DTO.PriceOffer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace hosamhemaily.PriceOffer
{
    public interface IPriceOfferAppService
    {
        public Task<Guid> CreateAsync(CreatePriceOfferDto input);

        public Task<List<PriceOfferDto>> GetAllAsync();

    }
}
