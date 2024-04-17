using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Xunit;

namespace hosamhemaily.TodoItems
{
    public abstract class TodoAppService_Tests<TStartupModule>: hosamhemailyApplicationTestBase<TStartupModule> where TStartupModule :IAbpModule
    {
        private readonly ITodoAppService _todoAppService;

        protected TodoAppService_Tests()
        {
            _todoAppService = GetRequiredService<ITodoAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_TodoItems()
        {
            //Act
            var result = await _todoAppService.GetListAsync();

            //Assert
            result.Count.ShouldBeGreaterThan(0);
            result.ShouldContain(b => b.Text == "1984");
        }
    }
}
