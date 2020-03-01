using _03_ToDoListTask.Factories.Contracts;
using _03_ToDoListTask.Models;
using _03_ToDoListTask.Models.Enums;
using _03_ToDoListTask.Services.Contracts;
using _03_ToDoListTask.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace _03_ToDoListTask.Factories
{
    public class TaskModelFactory : ITaskModelFactory
    {
        private readonly ITaskService _taskService;

        public TaskModelFactory(ITaskService taskService)
        {
            this._taskService = taskService;
        }

        public IList<TaskViewModel> CreateArchiveTaskViewModel(User user)
        {
            throw new NotImplementedException();
        }

        public TaskViewModel CreateEditTaskViewModel(int taskId, User user)
        {
            Task task = this._taskService.GetById(taskId);
            TaskViewModel model = new TaskViewModel
            {
                Title = task.Title,
                Content = task.Content,
                Id = task.Id
            };

            return model;
        }

        public IList<TaskViewModel> CreateIndexTaskViewModel(User user, bool isArchive)
        {
            IList<TaskViewModel> model = new List<TaskViewModel>();
            
            if (user != null)
            {
                IEnumerable<Task> filteredTasks = isArchive ? this._taskService.GetTasksByUserId(user.Id)
                                                        .Where(t => t.Status == TaskStatus.Done) : 
                                                  this._taskService.GetTasksByUserId(user.Id)
                                                        .Where(t => t.Status == TaskStatus.Active);
                foreach (Task task in filteredTasks)
                {
                    TaskViewModel taskModel = new TaskViewModel
                    {
                        Content = task.Content,
                        Title = task.Title,
                        Status = task.Status,
                        Id = task.Id
                    };

                    model.Add(taskModel);
                }
            }

            return model;
        }
    }
}
