using DTO.PriceOffer;
using hosamhemaily.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace hosamhemaily.PriceOffer
{
    public class PriceOfferAppService : ApplicationService,IPriceOfferAppService
    {
        private readonly IPriceOfferRepository _priceOfferRepository;

        public PriceOfferAppService(IPriceOfferRepository priceOfferRepository)
        {
            _priceOfferRepository = priceOfferRepository; 
        }
        public async Task<Guid> CreateAsync(CreatePriceOfferDto input)
        {
            var priceOffer = new Entities.PriceOffer.PriceOffer
            {
                AccountTrademarkId = input.AccountTrademarkId,
                ColorId = input.ColorId,
                PriceAgence = input.PriceAgence,
                PriceBank = input.PriceBank
            };
            var result =  await _priceOfferRepository.CreateAsync(priceOffer);
            return  result ;
        }

        public Task<List<PriceOfferDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
