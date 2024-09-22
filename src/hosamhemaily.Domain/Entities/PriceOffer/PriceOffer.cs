using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace hosamhemaily.Entities.PriceOffer
{
    public class PriceOffer : FullAuditedAggregateRoot<Guid>
    {
        public Guid AccountTrademarkId { get; set; }
        public Guid ColorId { get; set; }
        public decimal PriceAgence { get; set; }
        public decimal PriceBank { get; set; }

        public virtual AccountTrademark AccountTrademark { get; set; }
        public virtual Color Color { get; set; }

    }
}
