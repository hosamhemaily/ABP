using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace hosamhemaily
{
    public class TodoStoreDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<TodoItem, Guid> _todoRepository;
        private readonly ICurrentTenant _currentTenant;
        private readonly IGuidGenerator _guidGenerator;

        public TodoStoreDataSeedContributor(IRepository<TodoItem, Guid> todoRepository,
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant)
        {
            _todoRepository = todoRepository;
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context?.TenantId))
            {
                if (await _todoRepository.GetCountAsync() > 0)
                {
                    return;
                }
                var book = new TodoItem 
                {                 
                    MyText="First Do Item"
                };

                await _todoRepository.InsertAsync(book);
            }
        }
    }
}
