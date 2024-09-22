using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace hosamhemaily.Entities
{
    public class TodoItem : BasicAggregateRoot<Guid>
    {
        public string MyText { get; set; }
        public bool IsActive { get; set; }
        public TodoAddress? Address { get; set; }
    }
}
