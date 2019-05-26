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
    public partial class SprintsPage : ContentPage
    {
        SprintsViewModel viewModel;

        public SprintsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SprintsViewModel();
        }

        async void OnSprintSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var sprint = args.SelectedItem as SprintItem;
            if (sprint == null)
                return;

            await Navigation.PushAsync(new SprintDetailPage(new SprintDetailViewModel(sprint)));

            // Manually deselect item.
            SprintsListView.SelectedItem = null;
        }

        async void AddTask_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewSprintPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Sprints.Count == 0)
                viewModel.LoadSprintsCommand.Execute(null);
        }
    }
}