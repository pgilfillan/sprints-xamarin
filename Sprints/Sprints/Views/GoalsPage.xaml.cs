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
    public partial class GoalsPage : ContentPage
    {
        GoalsViewModel viewModel;

        public GoalsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new GoalsViewModel();
        }

        async void OnGoalSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var goal = args.SelectedItem as GoalItem;
            if (goal == null)
                return;

            await Navigation.PushAsync(new GoalDetailPage(new GoalDetailViewModel(goal)));

            // Manually deselect item.
            GoalsListView.SelectedItem = null;
        }

        async void AddGoal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewGoalPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Goals.Count == 0)
                viewModel.LoadGoalsCommand.Execute(null);
        }
    }
}