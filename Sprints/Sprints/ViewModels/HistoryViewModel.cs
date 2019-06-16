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
    public class HistoryViewModel : BaseViewModel
    {
        public IDataStore<SprintItem> DataStore => DependencyService.Get<IDataStore<SprintItem>>() ?? new SprintDataStore();
        public ObservableCollection<SprintItem> Sprints { get; set; }
        public Command LoadSprintsCommand { get; set; }

        public HistoryViewModel()
        {
            Title = "History";
            Sprints = new ObservableCollection<SprintItem>();
            LoadSprintsCommand = new Command(async () => await ExecuteLoadSprintsCommand());
        }

        async Task ExecuteLoadSprintsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Sprints.Clear();
                var sprints = await DataStore.GetItemsAsync(true);
                foreach (var sprint in sprints)
                {
                    Sprints.Add(sprint);
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