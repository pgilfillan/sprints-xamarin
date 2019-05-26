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
    public class GoalsViewModel : BaseViewModel
    {
        public IDataStore<GoalItem> DataStore => DependencyService.Get<IDataStore<GoalItem>>() ?? new GoalDataStore();
        public ObservableCollection<GoalItem> Goals { get; set; }
        public Command LoadGoalsCommand { get; set; }

        public GoalsViewModel()
        {
            Title = "Goals";
            Goals = new ObservableCollection<GoalItem>();
            LoadGoalsCommand = new Command(async () => await ExecuteLoadGoalsCommand());

            MessagingCenter.Subscribe<NewGoalPage, GoalItem>(this, "AddGoal", async (obj, goal) =>
            {
                var newGoal = goal as GoalItem;
                Goals.Add(newGoal);
                await DataStore.AddItemAsync(newGoal);
            });
        }

        async Task ExecuteLoadGoalsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Goals.Clear();
                var goals = await DataStore.GetItemsAsync(true);
                foreach (var goal in goals)
                {
                    Goals.Add(goal);
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