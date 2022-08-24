using DapperExample.Business.Concrete;
using DapperExample.DataAccess.Dapper;
using DapperExample.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DapperExample.UI.Controllers
{
    public class ToDoController : Controller
    {
        ToDoManager toDoManager = new ToDoManager(new DapTodoDal());
        public async Task<IActionResult> Index()
        {
            var values = await toDoManager.GetListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTodo()
        {
            return View();
        }
        public IActionResult RedirectToDelete(int id)
        {
            return RedirectToAction("DeleteTodo",new { todoId=id });
        }
        public IActionResult RedirectToUpdate(int id)
        {
            return RedirectToAction("UpdateTodo", new { todoId = id });
        }
        [HttpPost]
        public async Task<IActionResult> AddTodo(TodoItem todoItem)
        {
            todoItem.Status = true;
            await toDoManager.InsertAsync(todoItem);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTodo(int todoId)
        {
            var todoValue = await toDoManager.GetAsync(todoId);
            return View(todoValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTodo(TodoItem todoItem)
        {
            todoItem.Status = true;
            await toDoManager.UpdateAsync(todoItem.Id, todoItem);
            return View();
        }
        public async Task<IActionResult> DeleteTodo(int todoId)
        {
            await toDoManager.DeleteAsync(todoId);
            return RedirectToAction("Index");
        }
    }
}
