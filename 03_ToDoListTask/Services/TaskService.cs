using _03_ToDoListTask.Data;
using _03_ToDoListTask.Models;
using _03_ToDoListTask.Models.Enums;
using _03_ToDoListTask.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_ToDoListTask.Services
{
    public class TaskService : ITaskService
    {
        private readonly ToDoListDbContext context;

        public TaskService(ToDoListDbContext context)
        {
            this.context = context;
        }

        public void Archive(int taskId)
        {
            Task task = this.GetById(taskId);
            task.Status = TaskStatus.Done;
            this.context.SaveChanges();
        }

        public void Delete(Task task)
        {
            this.context.Tasks.Remove(task);
            this.context.SaveChanges();
        }

        public void Edit(int taskId, string taskTitle, string taskContent)
        {
            Task savedTask = this.GetById(taskId);
            savedTask.Title = taskTitle;
            savedTask.Content = taskContent;

            this.context.SaveChanges();
        }

        public Task GetById(int taskId)
        {
            return this.context.Tasks.FirstOrDefault(t => t.Id == taskId);
        }

        public IList<Task> GetTasksByUserId(int authorId)
        {
            return this.context.Tasks.Where(t => t.AuthorId == authorId).ToList();
        }

        public void Insert(Task task)
        {
            this.context.Tasks.Add(task);
            this.context.SaveChanges();
        }
    }
}
