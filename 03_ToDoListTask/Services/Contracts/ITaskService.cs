using _03_ToDoListTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace _03_ToDoListTask.Services.Contracts
{
    public interface ITaskService
    {
        Task GetById(int taskId);

        IList<Task> GetTasksByUserId(int authorId);

        void Insert(Task task);

        void Edit(int taskId, string taskTitle, string taskContent);

        void Delete(Task task);

        void Archive(int taskId);
    }
}
