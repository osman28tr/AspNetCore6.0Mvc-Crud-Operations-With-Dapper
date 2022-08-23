using Dapper;
using DapperExample.DataAccess.Abstract;
using DapperExample.DataAccess.Concrete;
using DapperExample.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.DataAccess.Dapper
{
    public class DapTodoDal : IToDoDal
    {
        public async Task DeleteAsync(Guid id)
        {
            await using var connection = new SqlConnection(Context.Connection());
            await connection.ExecuteAsync($"DELETE FROM dbo.TodoItems WHERE Id = '{id}'");
        }

        public async Task<TodoItem> GetAsync(Guid id)
        {
            await using var connection = new SqlConnection(Context.Connection());
            return await connection.QueryFirstAsync<TodoItem>($"SELECT * FROM dbo.TodoItems WHERE = '{id}'");
        }

        public async Task<List<TodoItem>> GetListAsync()
        {
            await using var connection = new SqlConnection(Context.Connection());

            return (await connection.QueryAsync<TodoItem>("SELECT * FROM dbo.TodoItems"))
                .AsList();
        }

        public async Task<TodoItem> InsertAsync(TodoItem todoItem)
        {
            await using var connection = new SqlConnection(Context.Connection());
            var query = $"INSERT INTO dbo.TodoItems VALUES ('{todoItem.Id}', '{todoItem.Title}', '{todoItem.Description}', {true})";
            await connection.ExecuteAsync(query);
            return todoItem;
        }

        public async Task<TodoItem> UpdateAsync(Guid id, TodoItem todoItem)
        {
            await using var connection = new SqlConnection(Context.Connection());
            await connection.ExecuteAsync($"UPDATE dbo.TodoItems SET {nameof(TodoItem.Title)} = '{todoItem.Title}', {nameof(TodoItem.Description)} = '{todoItem.Description}', {nameof(TodoItem.Status)} = {true} WHERE Id = '{id}'");
            return todoItem;
        }
    }
}
