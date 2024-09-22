using hosamhemaily.Entities.PriceOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosamhemaily.Repositorys
{
    public interface IPriceOfferRepository
    {
        Task<Guid> CreateAsync(PriceOffer entity);
        Task<List<PriceOffer>> GetAllAsync();
    }
}
