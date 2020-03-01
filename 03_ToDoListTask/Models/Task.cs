using _03_ToDoListTask.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_ToDoListTask.Models
{
    public class Task
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public TaskStatus Status { get; set; }
    }
}
