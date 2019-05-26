using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Sprints.Models;
using Sprints.Views;
using Sprints.ViewModels;

namespace Sprints.Views
{
    public partial class TasksPage : ContentPage
    {
        TasksViewModel viewModel;

        public TasksPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TasksViewModel();
        }

        async void OnTaskSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var task = args.SelectedItem as TaskItem;
            if (task == null)
                return;

            await Navigation.PushAsync(new TaskDetailPage(new TaskDetailViewModel(task)));

            // Manually deselect item.
            TasksListView.SelectedItem = null;
        }

        async void AddTask_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewTaskPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Tasks.Count == 0)
                viewModel.LoadTasksCommand.Execute(null);
        }
    }
}