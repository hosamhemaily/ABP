using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace hosamhemaily
{
    public interface ITodoAppService:IApplicationService
    {
        Task<List<TodoItemDto>> GetListAsync();
        Task<TodoItemDto> GetByAddressAsync();
        Task<TodoItemDto> CreateAync(string text);
        Task DeleteAync(int id);

        Task<bool> LinkCustomertoTodoItem(CustomertoTodoItemDTO dTO);
    }

   
}
