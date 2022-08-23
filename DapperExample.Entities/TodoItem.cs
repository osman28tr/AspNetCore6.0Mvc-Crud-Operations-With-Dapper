using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Entities
{
    public class TodoItem
    {
        public int Id { get; private set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
