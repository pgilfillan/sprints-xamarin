using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Sprints.Models;
using Sprints.ViewModels;

namespace Sprints.Views
{
    public partial class SprintDetailPage : ContentPage
    {
        SprintDetailViewModel viewModel;

        public SprintDetailPage(SprintDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public SprintDetailPage()
        {
            InitializeComponent();

            var sprint = new SprintItem
            {
                Title = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new SprintDetailViewModel(sprint);
            BindingContext = viewModel;
        }
    }
}