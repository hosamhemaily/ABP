using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace hosamhemaily.Entities.PriceOffer
{
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Category.Category Category { get; set; }

    }
}
