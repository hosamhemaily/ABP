using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace hosamhemaily
{
    public class TodoAppService : ApplicationService, ITodoAppService
    {
        private readonly IRepository<TodoItem, Guid> _todoItemRepository;
        public TodoAppService(IRepository<TodoItem, Guid> todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }
        public async Task<TodoItemDto> CreateAync(string text)
        {
            var result = await _todoItemRepository.InsertAsync(new TodoItem { MyText=text});
            return new TodoItemDto { Id=result.Id,Text=result.MyText};
        }

        public Task DeleteAync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TodoItemDto>> GetListAsync()
        {
            var result = await _todoItemRepository.GetListAsync();
            return result.Select(x=>new TodoItemDto {Id=x.Id,Text=x.MyText }).ToList();
        }
        
        public async Task<List<TodoItemDto>> Update()
        {
            var result = await _todoItemRepository.GetListAsync();
            return result.Select(x=>new TodoItemDto {Id=x.Id,Text=x.MyText }).ToList();
        }
        public async Task<List<TodoItemDto>> Reminder()
        {
            var result = await _todoItemRepository.GetListAsync();
            return result.Select(x=>new TodoItemDto {Id=x.Id,Text=x.MyText }).ToList();
        }
    }
}
