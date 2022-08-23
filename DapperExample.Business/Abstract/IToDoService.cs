using DapperExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Business.Abstract
{
    public interface IToDoService
    {
        public Task<List<TodoItem>> GetListAsync();
        public Task<TodoItem> GetAsync(Guid id);
        public Task<TodoItem> InsertAsync(TodoItem todoItem);
        public Task<TodoItem> UpdateAsync(Guid id, TodoItem todoItem);
        public Task DeleteAsync(Guid id);
    }
}
