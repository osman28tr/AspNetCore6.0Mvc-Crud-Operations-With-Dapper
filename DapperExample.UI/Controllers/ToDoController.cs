using DapperExample.Business.Concrete;
using DapperExample.DataAccess.Dapper;
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
    }
}
