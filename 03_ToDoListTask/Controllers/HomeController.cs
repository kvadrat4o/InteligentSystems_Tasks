using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _03_ToDoListTask.Models;
using _03_ToDoListTask.Data;
using _03_ToDoListTask.ViewModels;
using _03_ToDoListTask.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using _03_ToDoListTask.Models.Enums;
using _03_ToDoListTask.Factories.Contracts;

namespace _03_ToDoListTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ITaskService _taskService;

        private readonly UserManager<User> _userManager;

        private readonly ITaskModelFactory _taskModelFactory;
        public HomeController(ILogger<HomeController> logger, 
                              ITaskService taskService, 
                              UserManager<User> userManager,
                              ITaskModelFactory taskModelFactory)
        {
            this._logger = logger;
            this._taskService = taskService;
            this._userManager = userManager;
            this._taskModelFactory = taskModelFactory;
        }

        public IActionResult Index()
        {
            
            User user = GetUser();
            IList<TaskViewModel> model = this._taskModelFactory.CreateIndexTaskViewModel(user, false);
            return View(model);
        }

        public IActionResult Insert()
        {
            return View("InsertEdit", new TaskViewModel());
        }

        [HttpPost]
        public IActionResult Insert(TaskViewModel model)
        {
            Task task = new Task();
            task.Title = model.Title;
            task.Content = model.Content;
            task.Status = model.Status;

            task.Author = this._userManager.GetUserAsync(this.User).GetAwaiter().GetResult();

            this._taskService.Insert(task);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int taskId)
        {
            User user = GetUser();
            TaskViewModel model = this._taskModelFactory.CreateEditTaskViewModel(taskId, user);

            return View("InsertEdit",model);
        }
        [HttpPost]
        public IActionResult Edit(TaskViewModel model)
        {
            _taskService.Edit(model.Id, model.Title, model.Content);
            //return RedirectToAction("Edit", new { taskId = model.Id });
            return RedirectToAction("Index");
        }

        public IActionResult Archive()
        {
            User user = GetUser();

            IList<TaskViewModel> archivedTasks = this._taskModelFactory.CreateIndexTaskViewModel(user, true);

            return View(archivedTasks);
        }

        [HttpPost]
        public IActionResult Archive(int id)
        {
            this._taskService.Archive(id);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private User GetUser()
        {
            return this._userManager.GetUserAsync(this.User).GetAwaiter().GetResult();
        }
    }
}
