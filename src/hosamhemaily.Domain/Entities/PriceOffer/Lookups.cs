using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace hosamhemaily.Entities.PriceOffer
{
    public class Trademark : Entity<Guid>
    {
        public string Name { get; set; }
    }

    public class VehicleModel : Entity<Guid>
    {
        public string ModelName { get; set; }
    }

    public class VehicleType : Entity<Guid>
    {
        public string TypeName { get; set; }
    }

}
