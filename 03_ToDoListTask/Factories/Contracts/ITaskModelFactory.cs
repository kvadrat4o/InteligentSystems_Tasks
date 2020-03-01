using _03_ToDoListTask.Models;
using _03_ToDoListTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace _03_ToDoListTask.Factories.Contracts
{
    public interface ITaskModelFactory
    {
        public IList<TaskViewModel> CreateIndexTaskViewModel(User user, bool isArchive);

        public TaskViewModel CreateEditTaskViewModel(int taskId, User user);

    }
}
