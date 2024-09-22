using hosamhemaily.Entities;
using hosamhemaily.EntityFrameworkCore;
using hosamhemaily.Repositorys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace hosamhemaily
{
    public class TodoRepository : EfCoreRepository<hosamhemailyDbContext, TodoItem, Guid>, ITodoRepository

    {
        public TodoRepository(IDbContextProvider<hosamhemailyDbContext> dbContextProvider):base(dbContextProvider)
        {
                
        }
        public async Task<TodoItem> FindByAddressAsyns(string name)
        {
            var dbContext = await GetDbContextAsync();
            
            return await dbContext .Set<TodoItem>()
             .Where(p => p.Address.Street.Contains( name))
             .FirstOrDefaultAsync();
        }
    }
}
