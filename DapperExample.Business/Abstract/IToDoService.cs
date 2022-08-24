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
        public Task<TodoItem> GetAsync(int id);
        public Task<TodoItem> InsertAsync(TodoItem todoItem);
        public Task<TodoItem> UpdateAsync(int id, TodoItem todoItem);
        public Task DeleteAsync(int id);
    }
}
