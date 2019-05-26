using System;

using Sprints.Models;

namespace Sprints.ViewModels
{
    public class TaskDetailViewModel : BaseViewModel
    {
        public TaskItem Task { get; set; }
        public TaskDetailViewModel(TaskItem task = null)
        {
            Title = task?.Title;
            Task = task;
        }
    }
}
