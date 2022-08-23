using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.DataAccess.Concrete
{
    public class Context
    {
        public static string Connection()
        {
            return "Server=DESKTOP-7LR4Q85\\SQLEXPRESS;Database=DapperTodoDemo;Trusted_Connection=true";
        }
    }
}
