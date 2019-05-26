using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Sprints.Models;
using Sprints.Views;
using Sprints.Services;

namespace Sprints.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        public IDataStore<TaskItem> DataStore => DependencyService.Get<IDataStore<TaskItem>>() ?? new TaskDataStore();
        public ObservableCollection<TaskItem> Tasks { get; set; }
        public Command LoadTasksCommand { get; set; }

        public TasksViewModel()
        {
            Title = "Tasks";
            Tasks = new ObservableCollection<TaskItem>();
            LoadTasksCommand = new Command(async () => await ExecuteLoadTasksCommand());

            MessagingCenter.Subscribe<NewTaskPage, TaskItem>(this, "AddTask", async (obj, task) =>
            {
                var newTask = task as TaskItem;
                Tasks.Add(newTask);
                await DataStore.AddItemAsync(newTask);
            });
        }

        async Task ExecuteLoadTasksCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Tasks.Clear();
                var tasks = await DataStore.GetItemsAsync(true);
                foreach (var task in tasks)
                {
                    Tasks.Add(task);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}