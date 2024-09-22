using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosamhemaily.Entities.PriceOffer
{
    public class AccountTrademark
    {
        public Guid TrademarkId { get; set; }
        public Guid VehicleModelId { get; set; }
        public Guid VehicleTypeId { get; set; }

        public virtual Trademark Trademark { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
