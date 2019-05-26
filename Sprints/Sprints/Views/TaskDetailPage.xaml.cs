using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Sprints.Models;
using Sprints.ViewModels;

namespace Sprints.Views
{
    public partial class TaskDetailPage : ContentPage
    {
        TaskDetailViewModel viewModel;

        public TaskDetailPage(TaskDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public TaskDetailPage()
        {
            InitializeComponent();

            var task = new TaskItem
            {
                Title = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new TaskDetailViewModel(task);
            BindingContext = viewModel;
        }
    }
}