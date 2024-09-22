using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hosamhemaily.Entities
{
    public class TodoCity : ValueObject
    {
        public string Name { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
        }
    }
}
