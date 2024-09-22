using DTO;
using hosamhemaily.DomainServices;
using hosamhemaily.Entities;
using hosamhemaily.Repositorys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Users;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;



namespace hosamhemaily
{
    //[Authorize]
    public class TodoAppService : ApplicationService, ITodoAppService
    {
        private readonly IRepository<TodoItem, Guid> _todoItemRepository;
        private readonly ITodoRepository _todoRepository;
        private readonly TodoItemManager _todoItemManager;
        private readonly IAuditingManager _auditingManager;
        private readonly IPermissionManager _permissionManager;
        private readonly ICurrentUser _currentUser;
        private readonly IdentityUserManager _userManager; // To find user by username
        private readonly IdentityRoleManager _roleManager; // To find user by username
        private readonly IRepository<Volo.Abp.Identity.IdentityRole, Guid> _roleRepository;

        public TodoAppService(IRepository<TodoItem, Guid> todoItemRepository,
            TodoItemManager todoItemManager,
            IAuditingManager auditingManager,
            ITodoRepository todoRepository,
            IPermissionManager permissionManager,
            ICurrentUser currentUser,
            IdentityUserManager userManager,
            IdentityRoleManager roleManager,
            IRepository<Volo.Abp.Identity.IdentityRole, Guid> roleRepository)

        {
            _todoItemRepository = todoItemRepository;
            _todoItemManager = todoItemManager;
            _auditingManager = auditingManager;
            _todoRepository = todoRepository;
            _permissionManager = permissionManager;
            _currentUser = currentUser;
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;

        }
        public async Task<TodoItemDto> CreateAync(string text)
        {
            var result = await _todoItemRepository.InsertAsync(new TodoItem { MyText = text });
            return new TodoItemDto { Id = result.Id, Text = result.MyText };
        }

        public Task DeleteAync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TodoItemDto>> GetListAsync()
        {
            var result = await _todoItemRepository.GetListAsync();
            return result.Select(x => new TodoItemDto { Id = x.Id, Text = x.MyText }).ToList();
        }
        public async Task<TodoItemDto> GetByAddressAsync()
        {
            var result = await _todoRepository.FindByAddressAsyns("Ali Basha");
            return new TodoItemDto { Id = result.Id, Text = result.MyText };
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<bool> LinkCustomertoTodoItem(CustomertoTodoItemDTO dTO)
        {
            var currentAuditLogScope = _auditingManager.Current;
            currentAuditLogScope.Log.Comments.Add("Execute LinkCustomertoTodoItem");
            await _todoItemManager.CanLinkCustomertoitem(dTO.TodoItem, dTO.CustomerID);
            return true;
        }

        [Authorize(Roles ="admin")]
        public async Task<List<TodoItemDto>> Update()
        {
            var result = await _todoItemRepository.GetListAsync();
            return result.Select(x => new TodoItemDto { Id = x.Id, Text = x.MyText }).ToList();
        }

        
    }
}
