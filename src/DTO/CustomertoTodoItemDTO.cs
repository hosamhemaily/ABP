using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomertoTodoItemDTO
    {
        public int CustomerID { get; set; }
        public Guid TodoItem { get; set; }
    }
}
