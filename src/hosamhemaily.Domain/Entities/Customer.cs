﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace hosamhemaily.Entities
{
    public class Customer : FullAuditedAggregateRoot<int>
    {
        public string Name { get; set; }
    }
}