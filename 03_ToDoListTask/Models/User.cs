using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_ToDoListTask.Models
{
    public class User : IdentityUser<int>
    {
        public IList<Task> Tasks { get; set; }
    }
}
