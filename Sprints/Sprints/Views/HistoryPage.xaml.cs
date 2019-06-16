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
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel viewModel;

        public HistoryPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new HistoryViewModel();
        }

        async void OnSprintSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var sprint = args.SelectedItem as SprintItem;
            if (sprint == null)
                return;

            await Navigation.PushAsync(new SprintDetailPage(new SprintDetailViewModel(sprint)));

            // Manually deselect item.
            PastSprintsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Sprints.Count == 0)
                viewModel.LoadSprintsCommand.Execute(null);
        }
    }
}