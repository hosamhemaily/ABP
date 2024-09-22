using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hosamhemaily.Entities;

namespace hosamhemaily.Repositorys
{
    public interface ITodoRepository
    {
        Task<TodoItem> FindByAddressAsyns(string name);
    }
}
