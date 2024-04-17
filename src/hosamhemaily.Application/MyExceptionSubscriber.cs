using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ExceptionHandling;

namespace hosamhemaily
{
    public class MyExceptionSubscriber : ExceptionSubscriber
    {
        public override Task HandleAsync(ExceptionNotificationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
