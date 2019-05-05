using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Sprints.Models;
using Sprints.ViewModels;

namespace Sprints.Views
{
    public partial class GoalDetailPage : ContentPage
    {
        GoalDetailViewModel viewModel;

        public GoalDetailPage(GoalDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public GoalDetailPage()
        {
            InitializeComponent();

            var goal = new Goal
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new GoalDetailViewModel(goal);
            BindingContext = viewModel;
        }
    }
}