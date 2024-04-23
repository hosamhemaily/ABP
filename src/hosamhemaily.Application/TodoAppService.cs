using DTO;
using hosamhemaily.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Repositories;

namespace hosamhemaily
{
    public class TodoAppService : ApplicationService, ITodoAppService
    {
        private readonly IRepository<TodoItem, Guid> _todoItemRepository;
        private readonly TodoItemManager _todoItemManager;
        private readonly IAuditingManager _auditingManager;

        public TodoAppService(IRepository<TodoItem, Guid> todoItemRepository,TodoItemManager todoItemManager, 
            IAuditingManager auditingManager)
        {
            _todoItemRepository = todoItemRepository;
            _todoItemManager = todoItemManager;
            _auditingManager = auditingManager;

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

        public async Task LinkCustomertoTodoItem(CustomertoTodoItemDTO dTO)
        {
            var currentAuditLogScope = _auditingManager.Current;
            currentAuditLogScope.Log.Comments.Add("Execute LinkCustomertoTodoItem");
            await _todoItemManager.CanLinkCustomertoitem(dTO.TodoItem, dTO.CustomerID);
        }

        public async Task<List<TodoItemDto>> Update()
        {
            var result = await _todoItemRepository.GetListAsync();
            return result.Select(x=>new TodoItemDto {Id=x.Id,Text=x.MyText }).ToList();
        }

       
    }
}
