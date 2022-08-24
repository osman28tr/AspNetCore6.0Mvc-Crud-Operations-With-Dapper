using DapperExample.Business.Abstract;
using DapperExample.DataAccess.Abstract;
using DapperExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Business.Concrete
{
    public class ToDoManager : IToDoService
    {
        IToDoDal _toDoDal;
        public ToDoManager(IToDoDal toDoDal)
        {
            _toDoDal = toDoDal;
        }
        public async Task DeleteAsync(int id)
        {
            await _toDoDal.DeleteAsync(id);
        }

        public async Task<TodoItem> GetAsync(int id)
        {
           return await _toDoDal.GetAsync(id);
        }

        public async Task<List<TodoItem>> GetListAsync()
        {
            return await _toDoDal.GetListAsync();
        }

        public async Task<TodoItem> InsertAsync(TodoItem todoItem)
        {
            return await _toDoDal.InsertAsync(todoItem);
        }

        public async Task<TodoItem> UpdateAsync(int id, TodoItem todoItem)
        {
            return await _toDoDal.UpdateAsync(id, todoItem);
        }
    }
}
