using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace hosamhemaily.DomainServices
{
    public class TodoItemManager:DomainService
    {
        IRepository<TodoItem> _todorepository;
        IRepository<Customer> _customerrepository;
        public TodoItemManager(IRepository<TodoItem> todorepository, IRepository<Customer> customerrepository)
        {
            _todorepository=todorepository;
            _customerrepository=customerrepository;
        }
        public async Task CanLinkCustomertoitem(TodoItem item,Customer customer)
        {
            var resulttodoitem = await _todorepository.GetAsync(x=>x.Id==item.Id);
            var resultcustomer = await _customerrepository.GetAsync(x=>x.Id == customer.Id);
            if (resulttodoitem.IsActive) { }
        }
    }
}
